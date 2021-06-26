using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using DeloitteProject.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace DeloitteProject.Controllers
{
    public class IdentityUserController : Controller
    {
        private readonly UserManager<IdentityUser> _um;
        private readonly SignInManager<IdentityUser> _sm;
        public IdentityUserController(UserManager<IdentityUser> um,SignInManager<IdentityUser> sm)
        {
            _um = um;
            _sm = sm;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserClass uc)
        {
            var user =new IdentityUser{
                UserName=uc.UserName,
                Email=uc.Email,
            };
            var insertRec = await _um.CreateAsync(user,uc.pwd);
            if(insertRec.Succeeded)
            {
                ViewBag.message = "Account for " + uc.UserName + " created successfully";
                return View("Login");
            }
            else
            {
                foreach(var error in insertRec.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginClass obj)
        {
            if (ModelState.IsValid)
            {
                var result = await _sm.PasswordSignInAsync(obj.Email,obj.Password,false,false);                                    
                if(result.Succeeded)
                {
                    return RedirectToAction("Welcome","IdentityUser");
                }
                else
                {
                    ModelState.AddModelError("","Invalid credentials!");
                }
            }
            return View(obj);
        }
        [Authorize]
        public IActionResult Welcome()
        {
            ViewBag.message = User.Identity.Name;

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _sm.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
