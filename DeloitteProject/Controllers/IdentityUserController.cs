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
using DeloitteProject.Data;

namespace DeloitteProject.Controllers
{
    public class IdentityUserController : Controller
    {
        private readonly UserManager<IdentityUser> _um;
        private readonly SignInManager<IdentityUser> _sm;
        private readonly ApplicationDbContext _db;
        public IdentityUserController(UserManager<IdentityUser> um,SignInManager<IdentityUser> sm,ApplicationDbContext db)
        {
            _um = um;
            _sm = sm;
            _db = db;
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
                PhoneNumber=uc.PhoneNumber
            };
            var insertRec = await _um.CreateAsync(user,uc.pwd);
            if (insertRec.Succeeded)
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
                var result = await _sm.PasswordSignInAsync(obj.UserName, obj.Password,false,false);                                    
                if(result.Succeeded)
                {
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("","Invalid credentials!");
                }
            }
            return View(obj);
        }

        [Authorize]
        public async Task<IActionResult> Welcome(string id)
        {

            var user = await _um.FindByIdAsync(id);
            ViewBag.username = user.UserName;

            return View(user);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Welcome(IdentityUser obj)
        {
            if (ModelState.IsValid)
            {
                var user = await _um.FindByIdAsync(obj.Id);
                user.UserName = obj.UserName;
                user.Email = obj.Email;
                user.PhoneNumber = obj.PhoneNumber;
                var result = await _um.UpdateAsync(user);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                
            }
            return View(obj);
        }

        public async Task<IActionResult> Logout()
        {
            await _sm.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
