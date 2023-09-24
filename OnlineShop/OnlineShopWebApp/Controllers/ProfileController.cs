using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.db;
using OnlineShop.db.Models;
using OnlineShopWebApp.Models;
using System;
using System.IO;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IWebHostEnvironment appEnvironment;
        private readonly IMapper mapper;

        public ProfileController(UserManager<User> userManager, SignInManager<User> signInManager, IWebHostEnvironment appEnvironment, IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.appEnvironment = appEnvironment;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            return View(mapper.Map<UserDataViewModdel>(userManager.FindByNameAsync(User.Identity.Name).Result));
        }
        public IActionResult SingIn(string returnUrl)
        {
            return View(new Login() { ReturnUrl = returnUrl});
        }
        public IActionResult Registration(string returnUrl)
        {
            return View(new Registration() { ReturnUrl = returnUrl });
        }
        [HttpPost]
        public IActionResult VerifyData(Login login)
        {
            if (ModelState.IsValid)
            {
                var result = signInManager.PasswordSignInAsync(login.LoginUser, login.Password, login.Remember, false).Result;
                if (result.Succeeded)
                {
                    if (login.ReturnUrl == null)
                    {
                        return Redirect("/Home/Index");
                    }
                    return Redirect(login.ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Логин или пароль указан не верно");
                }
            }
            return View("SingIn", new Login() { ReturnUrl = null });
        }
        [HttpPost]
        public IActionResult VerifyRegistrationData(Registration registration)
        {
            if (ModelState.IsValid)
            {
                if (userManager.FindByNameAsync(registration.Login).Result == null)
                {
                    var admin = new User { UserName = registration.Login };

                    var result = userManager.CreateAsync(admin, registration.Password).Result;

                    if (result.Succeeded)
                    {
                        userManager.AddToRoleAsync(admin, Constans.UserRoleName).Wait();
                        var resultCookie = signInManager.PasswordSignInAsync(registration.Login, registration.Password, false, false).Result;
                        if (resultCookie.Succeeded)
                        {
                            if (registration.ReturnUrl == null)
                            {
                                return Redirect("/Home/Index");
                            }
                            return Redirect(registration.ReturnUrl);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("Lodin", "Пользователь с данным логином уже существует");
                }
            }
            return View("Registration");
        }

        [HttpPost]
        public IActionResult SaveData(UserDataViewModdel user)
        {
            var redact = userManager.FindByNameAsync(User.Identity.Name).Result;
            redact.Email = user.Email;
            redact.PhoneNumber = user.PhoneNumber;
            redact.FirstName = user.FirstName;
            redact.LastName = user.LastName;
            userManager.UpdateAsync(redact).Wait();
            return RedirectToAction("Index", "Profile");
        }
        [HttpPost]
        public IActionResult RedactImg(RedactImgUser redactImgUser) 
        {
            if (redactImgUser.UploadedFile != null) 
            {
                string productImgPath = Path.Combine(appEnvironment.WebRootPath + "/images/users/");
                if (!Directory.Exists(productImgPath))
                {
                    Directory.CreateDirectory(productImgPath);
                }
                if(redactImgUser.ImgPath != null)
                {
                    System.IO.File.Delete(appEnvironment.WebRootPath + redactImgUser.ImgPath);
                }
                var fileName = Guid.NewGuid() + "." + redactImgUser.UploadedFile.FileName.Split('.').Last();
                using (var fileStream = new FileStream(productImgPath + fileName, FileMode.Create))
                {
                    redactImgUser.UploadedFile.CopyTo(fileStream);
                }
                redactImgUser.ImgPath = "/images/users/" + fileName;

                var redact = userManager.FindByNameAsync(User.Identity.Name).Result;

                redact.ImgPath = redactImgUser.ImgPath;
                userManager.UpdateAsync(redact).Wait();
            }
            return RedirectToAction("Index", "Profile");
        }
        public IActionResult DeleteImg(RedactImgUser redactImgUser)
        {
            if (redactImgUser.ImgPath != null)
            {
                System.IO.File.Delete(appEnvironment.WebRootPath + redactImgUser.ImgPath);

                var redact = userManager.FindByNameAsync(User.Identity.Name).Result;

                redact.ImgPath = null;
                userManager.UpdateAsync(redact).Wait();
            }
            return RedirectToAction("Index", "Profile");
        }
        public IActionResult LogOut()
        {
            signInManager.SignOutAsync().Wait();
            return Redirect("/home/index");
        }
    }
}
