using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.db;
using OnlineShop.db.Models;
using OnlineShopWebApp.Models;
using System.Linq;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IMapper mapper;

        public UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(userManager.Users.ToList());
        }
        [HttpPost]
        public IActionResult Add(UserViewModel user)
        {
            if(ModelState.IsValid)
            {
                if(userManager.FindByNameAsync(user.Login).Result == null)
                {
                    var newUser = new User 
                    { 
                        Email = user.Email, 
                        UserName = user.Login, 
                        FirstName = user.FirstName, 
                        LastName = user.LastName,
                        PhoneNumber = user.PhoneNumber
                    };
                    if(user.Role == null)
                    {
                        user.Role = "User";
                    }

                    var result = userManager.CreateAsync(newUser, user.Password).Result;

                    if (result.Succeeded)
                    {
                        userManager.AddToRoleAsync(newUser, user.Role).Wait();
                    }
                }
                else
                {
                    ModelState.AddModelError("Lodin", "Пользователь с данным логином уже существует");
                }
            }
            return View("Index", userManager.Users.ToList());
        }
        public IActionResult Show(string userLogin)
        {
            var user = mapper.Map<UserViewModel>(userManager.FindByNameAsync(userLogin).Result);

            user.Role = userManager.GetRolesAsync(userManager.FindByNameAsync(userLogin).Result).Result.First();
            return View(user);
        }
        
        public IActionResult Redact(UserViewModel user)
        {
            var redact = userManager.FindByNameAsync(user.Login).Result;
            redact.UserName = user.Login;
            redact.Email = user.Email;
            redact.PhoneNumber = user.PhoneNumber;
            redact.FirstName = user.FirstName;
            redact.LastName = user.LastName;
            userManager.UpdateAsync(redact).Wait();

            return RedirectToAction("Show", new { userLogin = user.Login });
        }
        public IActionResult RedactPassword(UserViewModel user)
        {
            var redact = userManager.FindByNameAsync(user.Login).Result;
            userManager.ChangePasswordAsync(redact, redact.PasswordHash ,user.Password).Wait();

            return RedirectToAction("Show", new { userLogin = user.Login });
        }
        public IActionResult Remove(string userLogin)
        {
            var removeUser = userManager.FindByNameAsync(userLogin).Result;
            userManager.DeleteAsync(removeUser).Wait();

            return RedirectToAction("Index");
        }
        public IActionResult SwitchRole(string userLogin, string userRole)
        {
            var user = userManager.FindByNameAsync(userLogin).Result;
            userManager.RemoveFromRoleAsync(user, userManager.GetRolesAsync(userManager.FindByNameAsync(userLogin).Result).Result.First()).Wait();
            userManager.AddToRoleAsync(user, userRole).Wait();

            return RedirectToAction("Show", new { userLogin });
        }
    }
}
