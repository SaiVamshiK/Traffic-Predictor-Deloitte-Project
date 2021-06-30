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
using DeloitteProject.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace DeloitteProject.Controllers
{
    public class IdentityUserController : Controller
    {
        private readonly UserManager<IdentityUser> _um;
        private readonly SignInManager<IdentityUser> _sm;
        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment hostingEnvironment;
        public IdentityUserController(UserManager<IdentityUser> um,SignInManager<IdentityUser> sm,ApplicationDbContext db, IHostingEnvironment hostingEnvironment)
        {
            _um = um;
            _sm = sm;
            _db = db;
            this.hostingEnvironment = hostingEnvironment;
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
            var user = await _um.GetUserAsync(User);
            return View(user);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Dashboard(string id)
        {
            IEnumerable<UserUpload> mainObj = _db.UserUpload;
            IList<UserUpload> objList = new List<UserUpload>();

            foreach (var obj in mainObj)
            {
                objList.Add(new UserUpload()
                {
                    Name = obj.Name,
                    CreatedDate = obj.CreatedDate,
                    fileName = obj.fileName
                });
            }
            ViewData["entries"] = objList;
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Welcome(string id)
        {

            var user = await _um.FindByIdAsync(id);

            return View(user);
        }

        [Authorize]
        public async Task<IActionResult> Upload(string id)
        {
            var user = await _um.FindByIdAsync(id);
            
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Upload(UserUploadViewModel model)
        {
            var user = await _um.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.File != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "temp");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.File.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.File.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                UserUpload newUpload = new UserUpload
                {
                    Name = user.UserName,
                    filePath = uniqueFileName,
                    fileName=model.File.FileName
                };

                _db.UserUpload.Add(newUpload);
                _db.SaveChanges();
                TempData["SuccessMessage"] = "The file has been uploaded successfully.";
                return RedirectToAction("Dashboard");
            }

            return View();
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
        [Authorize]
        [HttpGet]
        public IActionResult PasswordReset()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PasswordReset(ResetPassword obj)
        {
            
            if (ModelState.IsValid)
            {
                var user = await _um.GetUserAsync(User);
                if (user==null)
                {
                    return RedirectToAction("Login");
                }
                var result = await _um.ChangePasswordAsync(user, obj.CurrentPassword, obj.NewPassword);
                if(!result.Succeeded)
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View();
                }
                await _sm.RefreshSignInAsync(user);
                return View("Index");
            }
            return View();
        }


    }
}
