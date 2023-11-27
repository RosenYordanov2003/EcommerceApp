namespace EcommerceApp.Controllers
{
    using System.Security.Claims;
    using System.IdentityModel.Tokens.Jwt;
    using System.Text;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using Config;
    using Core.Contracts;
    using Infrastructure.Data.Models;
    using Models.Account;
    using Models.Requests;
    using EcommerceApp.Models.Responses;

    [ApiController]
    [Route("api/account")]
    [Produces("application/json")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly JwtConfig jwtConfig;
        private readonly TokenValidationParameters tokenValidationParameters;
        private readonly IAuthService authService;
        public AccountController(UserManager<IdentityUser> userManager,
            IOptionsMonitor<JwtConfig> optionsMonitor,
            TokenValidationParameters tokenValidationParameters,
            IAuthService authService)
        {
            this.userManager = userManager;
            this.jwtConfig = optionsMonitor.CurrentValue;
            this.tokenValidationParameters = tokenValidationParameters;
            this.authService = authService;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            bool isExsitsByEmail = await userManager.FindByEmailAsync(registerModel.Email) != null;
            bool isExistsByUsername = await userManager.FindByNameAsync(registerModel.UserName) != null;
            if (!ModelState.IsValid || isExsitsByEmail || isExistsByUsername)
            {
                return BadRequest();
            }
            var newUser = new IdentityUser()
            {
                Email = registerModel.Email,
                UserName = registerModel.UserName,
            };
            var result = await userManager.CreateAsync(newUser, registerModel.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new RegisterResponse() { Erros = errors.ToList() });
            }
            return Ok(new {Message = "You have successfully created an account"});
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {

            var user = await userManager.FindByNameAsync(loginModel.Username);
            if (user != null)
            {
                bool passwordResult = await userManager.CheckPasswordAsync(user, loginModel.Password);
                if (!passwordResult)
                {
                    return BadRequest(new { Error = "Invalid Password!" });
                }
                else
                {
                    HttpContext.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
                    HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "https://localhost:44440");
                    HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "Set-Cookie");

                    AuthResult authResult = await GenerateJwtToken(user);
                    HttpContext.Response.Cookies.Append("token", authResult.Token, new CookieOptions()
                    {
                        HttpOnly = true,
                        IsEssential = true,
                        SameSite = SameSiteMode.None,
                        Secure = true,
                        Expires = DateTimeOffset.UtcNow.AddMinutes(15),
                    });
                    return Ok(new LoginResponse() { Username = loginModel.Username });
                }
            }
            return BadRequest(new { Error = "Username does not exist!" });

        }

        [HttpPost]
        [Route("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenRequest tokenRequest)
        {
            if (ModelState.IsValid)
            {
                AuthResult result = await VerifyToken(tokenRequest);

                if (result == null)
                {
                    return BadRequest(new AuthResult()
                    {
                        Errors = new List<string>() {
                             "Invalid tokens"
                        },
                        Success = false
                    });
                }
                return Ok(result);
            }
            return BadRequest(new AuthResult()
            {
                Errors = new List<string>() {
                "Invalid payload"
            },
                Success = false
            });
        }
        private async Task<AuthResult> GenerateJwtToken(IdentityUser user)
        {
            JwtSecurityTokenHandler jwtTokenHandler = new JwtSecurityTokenHandler();

            byte[] key = Encoding.ASCII.GetBytes(jwtConfig.Secret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };
            SecurityToken token = jwtTokenHandler.CreateToken(tokenDescriptor);
            string jwtToken = jwtTokenHandler.WriteToken(token);

            RefreshToken refreshToken = await authService.GenerateRefreshTokenAsync(user.Id, token.Id);

            SetRefreshToken(refreshToken);

            return new AuthResult()
            {
                Token = jwtToken,
                RefreshToken = refreshToken.Token,
                Success = true,

            };
        }

        private void SetRefreshToken(RefreshToken refreshToken)
        {
            HttpContext.Response.Cookies.Append("X-Refresh-Token", refreshToken.Token,
                new CookieOptions
                {
                    Expires = refreshToken.ExpireData,
                    HttpOnly = true,
                    IsEssential = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                });
        }

        private async Task<AuthResult> VerifyToken(TokenRequest tokenRequest)
        {
            JwtSecurityTokenHandler jwtTokenHandler = new JwtSecurityTokenHandler();
            try
            {
                // This validation function will make sure that the token meets the validation parameters
                // and its an actual jwt token not just a random string
                ClaimsPrincipal principal = jwtTokenHandler.ValidateToken(tokenRequest.Token, tokenValidationParameters, out SecurityToken validatedToken);

                // Now we need to check if the token has a valid security algorithm
                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    bool result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);

                    if (!result)
                    {
                        return null;
                    }
                }

                // Will get the time stamp in unix time
                long utcExpiryDate = long.Parse(principal.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

                // we convert the expiry date from seconds to the date
                var expDate = UnixTimeStampToDateTime(utcExpiryDate);

                if (expDate > DateTime.UtcNow)
                {
                    return new AuthResult()
                    {
                        Errors = new List<string>() { "We cannot refresh this since the token has not expired" },
                        Success = false
                    };
                }

                // Check the token we got if its saved in the db
                bool isRefreshTokenExists = await authService.CheckIsRefreshTokenExistAsync(tokenRequest.RefreshToken);

                if (!isRefreshTokenExists)
                {
                    return new AuthResult()
                    {
                        Errors = new List<string>() { "refresh token doesnt exist" },
                        Success = false
                    };
                }
                RefreshToken refreshToken = await authService.FindRefreshTokenAsync(tokenRequest.RefreshToken);

                // Check the date of the saved token if it has expired
                if (DateTime.UtcNow > refreshToken.ExpireData)
                {
                    return new AuthResult()
                    {
                        Errors = new List<string>() { "token has expired, user needs to re-login" },
                        Success = false
                    };
                }

                // check if the refresh token has been used
                if (refreshToken.IsUsed)
                {
                    return new AuthResult()
                    {
                        Errors = new List<string>() { "token has been used" },
                        Success = false
                    };
                }

                // Check if the token is revoked
                if (refreshToken.IsRevoked)
                {
                    return new AuthResult()
                    {
                        Errors = new List<string>() { "token has been revoked" },
                        Success = false
                    };
                }

                // we are getting here the jwt token id
                string jti = principal.Claims.SingleOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

                // check the id that the recieved token has against the id saved in the db
                if (refreshToken.JwtId != jti)
                {
                    return new AuthResult()
                    {
                        Errors = new List<string>() { "the token does not matched the saved token" },
                        Success = false
                    };
                }

                await authService.SetRefreshTokenIsUsed(refreshToken.Token);

                IdentityUser dbUser = await userManager.FindByIdAsync(refreshToken.UserId);

                return await GenerateJwtToken(dbUser);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToUniversalTime();
            return dtDateTime;
        }
    }
}
