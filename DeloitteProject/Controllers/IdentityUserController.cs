using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using DeloitteProject.Models;

namespace DeloitteProject.Controllers
{
    public class IdentityUserController : Controller
    {
        private readonly UserManager<IdentityUser> _um;
        public IdentityUserController(UserManager<IdentityUser> um)
        {
            _um = um;
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
                UserName=uc.Email,
                Email=uc.Email,
            };
            var insertRec = await _um.CreateAsync(user,uc.pwd);
            if(insertRec.Succeeded)
            {
                ViewBag.message = "The user with email:" + uc.Email + " is saved successfully";
                return View("Index");
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
    }
}
