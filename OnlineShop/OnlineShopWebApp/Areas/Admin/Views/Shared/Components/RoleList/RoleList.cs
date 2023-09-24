using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using System.Linq;

namespace OnlineShopWebApp.Areas.Admin.Views.Shared.Components.RoleList
{
    public class RoleList : ViewComponent
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleList(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IViewComponentResult Invoke()
        {
            return View("RoleList", roleManager.Roles.ToList());
        }
    }
}
