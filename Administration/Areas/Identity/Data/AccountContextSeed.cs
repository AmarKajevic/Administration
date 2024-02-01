using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Administration.Areas.Identity.Data
{
    public class AccountContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<IdentityUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user1 = new IdentityUser
                {
                    Email = "emirbasovic04@gmail.com",
                    UserName = "emirbasovic04@gmail.com",
                    EmailConfirmed = true,
                };
                await userManager.CreateAsync(user1, "Admin12.");
                await userManager.AddClaimAsync(user1, new Claim("Position", "Admin"));

                var user2 = new IdentityUser
                {
                    Email = "languramilos89@gmail.com",
                    UserName = "languramilos89@gmail.com",
                    EmailConfirmed = true,
                };
                await userManager.CreateAsync(user2, "Admin12.");
                await userManager.AddClaimAsync(user2, new Claim("Position", "Admin"));
            }
        }
    }
}