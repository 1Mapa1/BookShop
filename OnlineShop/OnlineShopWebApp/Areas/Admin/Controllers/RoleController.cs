using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System.Linq;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View(roleManager.Roles.ToList());
        }
        public IActionResult Remove(string roleName)
        {
            roleManager.DeleteAsync(roleManager.FindByNameAsync(roleName).Result).Wait();
            return RedirectToAction("Index", "Role");
        }
        
        [HttpPost]
        public IActionResult Add(RoleViewModel role)
        {
            if (ModelState.IsValid)
            {
                if (roleManager.FindByNameAsync(role.NameRole).Result == null)
                {
                    roleManager.CreateAsync(new IdentityRole(role.NameRole)).Wait();
                }
                else
                {
                    ModelState.AddModelError("", "Попытка создать роль с одинаковыми именами");
                }
            }
            return View("Index", roleManager.Roles.ToList());
        }
    }
}
