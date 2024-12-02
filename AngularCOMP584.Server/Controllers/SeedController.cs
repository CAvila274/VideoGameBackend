using AngularCOMP584.Server.data;
using CsvHelper;
using CsvHelper.Configuration;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;

namespace AngularCOMP584.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController(DataBaseWrapperContext db,IHostEnvironment environment, UserManager<AppUser> userManager) : ControllerBase
    {
        

        [HttpPost("User")]
        public async Task<ActionResult> ImportUserAsync()
        {
            (string name, string email) = ("Christian", "christian@email.com");
            AppUser user = new AppUser()
            {
                UserName = name,
                Email = email,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            if (await userManager.FindByEmailAsync(email) is not null)
            {
                return Ok(user);

            }

            

            await userManager.CreateAsync(user, "VideoGamesisthebest123!");
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            await db.SaveChangesAsync();
            return Ok(user);
        }
    }
}
    

