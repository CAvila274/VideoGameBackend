using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.IdentityModel.Tokens.Jwt;
using DataModel;
using AngularCOMP584.Server.DTO;

namespace AngularCOMP584.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController(UserManager<AppUser> userManager, JwtHandling jwtHandler) : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<ActionResult> LoginAsync(DTO.LoginRequest request)
        {

            AppUser? user = await userManager.FindByNameAsync(request.UserName);

            if (user == null)
            {
                return Unauthorized("Bad Username");
            }

            bool success = await userManager.CheckPasswordAsync(user, request.Password);

            if (!success)
            {
                return Unauthorized("Bad Password");
            }

            JwtSecurityToken token = await jwtHandler.GetSecurityTokenAsync(user);

            string jwtstring = new JwtSecurityTokenHandler().WriteToken(token);

            LoginResponse response = new()
            {
                Success = true,
                Message = "hello",
                Token = jwtstring,
            };
            return Ok(response);
        }
    }
}
