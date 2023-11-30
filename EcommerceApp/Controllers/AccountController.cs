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
    using EcommerceApp.Models.Responses;
    using System.Linq;

    [ApiController]
    [Route("api/account")]
    [Produces("application/json")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly JwtConfig jwtConfig;
        private readonly TokenValidationParameters tokenValidationParameters;
        private readonly IAuthService authService;
        public AccountController(UserManager<User> userManager,
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
            var newUser = new User()
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
            return Ok(new { Message = "You have successfully created an account" });
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

        [HttpGet]
        [Route("RefreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            string refreshToken = Request.Cookies["X-Refresh-Token"];
            User user = await authService.GetUserByRefreshTokenAsync(refreshToken);

            if (user == null || !await authService.CheckIsRefreshTokenExistAsync(refreshToken))
            {
                return Unauthorized("There is no active token");
            }
            if (!await authService.CheckIfRefreshTokenIsActiveAsync(refreshToken))
            {
                return Unauthorized("Token has expired");
            }

            AuthResult authResult = await GenerateJwtToken(user);
            HttpContext.Response.Cookies.Append("token", authResult.Token, new CookieOptions()
            {
                HttpOnly = true,
                IsEssential = true,
                SameSite = SameSiteMode.None,
                Secure = true,
                Expires = DateTimeOffset.UtcNow.AddMinutes(15),
            });

            return Ok(new { Username = user.UserName });
        }
        [HttpGet]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            string jwtToken = Request.Cookies["token"];
            string refreshToken = Request.Cookies["X-Refresh-Token"];

            if (jwtToken != null && refreshToken != null)
            {
                HttpContext.Response.Cookies.Append("token", jwtToken, new CookieOptions()
                {
                    HttpOnly = true,
                    IsEssential = true,
                    SameSite = SameSiteMode.None,
                    Secure = true,
                    Expires = DateTimeOffset.UtcNow.AddMinutes(-2),
                });

               HttpContext.Response.Cookies.Append("X-Refresh-Token", refreshToken,
               new CookieOptions
               {
                   Expires = DateTimeOffset.UtcNow.AddMinutes(-2),
                   HttpOnly = true,
                   IsEssential = true,
                   Secure = true,
                   SameSite = SameSiteMode.None,
               });
                return Ok();
            }
            return BadRequest();
        }
        private async Task<AuthResult> GenerateJwtToken(User user)
        {
            JwtSecurityTokenHandler jwtTokenHandler = new JwtSecurityTokenHandler();

            byte[] key = Encoding.ASCII.GetBytes(jwtConfig.Secret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
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
    }
}
