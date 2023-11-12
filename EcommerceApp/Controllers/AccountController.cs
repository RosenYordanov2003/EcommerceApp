using EcommerceApp.Config;
using EcommerceApp.Models.Account;
using Microsoft.AspNetCore.Http;
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
        public AccountController(UserManager<IdentityUser> userManager, 
            IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            this.userManager = userManager;
            this.jwtConfig = optionsMonitor.CurrentValue;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            bool isExsit = await userManager.FindByEmailAsync(registerModel.Email) == null;
            //if (!ModelState.IsValid || isExsit)
            //{ 
            //    return BadRequest();
            //}
            var newUser = new IdentityUser()
            {
                Email = registerModel.Email,
                UserName = registerModel.UserName,
            };
            var result = await userManager.CreateAsync(newUser, registerModel.Password);

            if (result.Succeeded)
            {
                string jwtToken = GenerateJwtToken(newUser);
                //return new StatusCodeResult(201);
                return Ok(new {Token = jwtToken });
            }
            else
            {
                var errors =result.Errors.Select(e => e.Description);
                return BadRequest(new { erors = errors });
            }
        }
        private string GenerateJwtToken(IdentityUser user)
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
                Expires = DateTime.UtcNow.AddHours(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };
            SecurityToken token = jwtTokenHandler.CreateToken(tokenDescriptor);
            string jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}
