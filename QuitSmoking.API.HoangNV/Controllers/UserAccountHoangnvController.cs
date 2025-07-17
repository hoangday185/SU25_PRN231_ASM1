using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using QuitSmoking.Repositories.HoangNV.Models;
using QuitSmoking.Services.HoangNV;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QuitSmoking.API.HoangNV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountHoangnvController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UserService _userService; //// don't forget add Dependency Injection in program.cs

        public UserAccountHoangnvController(IConfiguration config, UserService userService)
        {
            _config = config;
            _userService = userService;     //// Add DJ
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _userService.loginAsync(request.UserName, request.Password);

            if (user == null || user.Result == null)
            {
                return Unauthorized();
            }

            var token = GenerateJSONWebToken(user.Result);

            return Ok(token);
        }

        private string GenerateJSONWebToken(UserAccountHoangNv systemUserAccount)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"]
                    , _config["Jwt:Audience"]
                    , new Claim[]
                    {
                new(ClaimTypes.Name, systemUserAccount.UserName),
                //new(ClaimTypes.Email, systemUserAccount.Email),
                new(ClaimTypes.Role, systemUserAccount.RoleId.ToString()),
                new(ClaimTypes.NameIdentifier, systemUserAccount.UserAccountHoangNvid.ToString()),
                    },
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }



        public sealed record LoginRequest(string UserName, string Password);


    }
}
