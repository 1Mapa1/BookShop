

using Microsoft.AspNetCore.Identity;
using OnlineShop.db.Models;

namespace OnlineShop.db
{
    public class IdentityInitializer
    {
        public static void Initialize(UserManager<User> userManager, RoleManager<IdentityRole> roleManager) 
        {
            var adminEmail = "admin@gmail.com";
            var password = "!@C171k!";

            if (roleManager.FindByNameAsync(Constans.AdminRoleName).Result == null) 
            { 
                roleManager.CreateAsync(new IdentityRole(Constans.AdminRoleName)).Wait();
            }
            if (roleManager.FindByNameAsync(Constans.UserRoleName).Result == null)
            {
                roleManager.CreateAsync(new IdentityRole(Constans.UserRoleName)).Wait();
            }
            if (userManager.FindByNameAsync("Admin").Result == null)
            { 
                var admin = new User { Email= adminEmail, UserName = "Admin" };
                
                var result = userManager.CreateAsync(admin, password).Result;

                if (result.Succeeded) 
                {
                    userManager.AddToRoleAsync(admin, Constans.AdminRoleName).Wait();
                }
            }
        }
    }
}
