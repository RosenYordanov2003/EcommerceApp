using EcommerceApp.Config;
using EcommerceApp.Core.Contracts;
using EcommerceApp.Infrastructure.Data.Models;
using EcommerceApp.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EcommerceApp.Controllers
{
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
            bool isExsit = await userManager.FindByEmailAsync(registerModel.Email) == null;
            if (!ModelState.IsValid || isExsit)
            {
                return BadRequest();
            }
            var newUser = new IdentityUser()
            {
                Email = registerModel.Email,
                UserName = registerModel.UserName,
            };
            var result = await userManager.CreateAsync(newUser, registerModel.Password);

            if (result.Succeeded)
            {
                AuthResult authResult = await GenerateJwtToken(newUser);
               
                return Ok(authResult);
            }
            else
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new { erors = errors });
            }
        }
        private async Task<AuthResult> GenerateJwtToken(IdentityUser user)
        {
            JwtSecurityTokenHandler jwtTokenHandler = new JwtSecurityTokenHandler();

            byte[] key = Encoding.ASCII.GetBytes(jwtConfig.Secret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new [] 
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

            return new AuthResult()
            {
                Token = jwtToken,
                RefreshToken = refreshToken.Token,
                Success = true,
            };
        }
    }
}
