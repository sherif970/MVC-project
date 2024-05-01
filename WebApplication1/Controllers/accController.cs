using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.view_models;

namespace WebApplication1.Controllers
{
    public class accController : Controller
    {
        private readonly UserManager<applicationuser> usermanger;
        private readonly SignInManager<applicationuser> signin;

        public accController(UserManager<applicationuser> usermanger , SignInManager<applicationuser> signin )
        {
            this.usermanger = usermanger;
            this.signin = signin;
        }
       public async Task<IActionResult> login ( loginuser uservm)
        {
            if (ModelState.IsValid)
            {
                applicationuser user = await usermanger.FindByNameAsync(uservm.name);
                if (user != null )
                {
                    bool found = await usermanger.CheckPasswordAsync(user , uservm.password);
                    if (found == true)
                    {
                       await signin.SignInAsync(user, uservm.rememberme);
                        return RedirectToAction("Index", "employee");
                    }
                    else
                    {
                        ModelState.AddModelError("password", "the passord is wrong");
                        return View(uservm);
                    }
                }
                ModelState.AddModelError("name", "the username is wrong");
                return View(uservm);

            }
            else
            {
                return View(uservm);
            }
        }
        
        public async Task<IActionResult> reegistr(registeruserviewmodel newvm)
        {
            applicationuser user = new applicationuser();
            if(ModelState .IsValid)
            {
                user.UserName = newvm.username;
                user.address = newvm.address;
                user.PasswordHash = newvm.password;
               IdentityResult result= await usermanger.CreateAsync(user, newvm.password);
                if (result.Succeeded)
                {
                   await signin.SignInAsync(user, false);
                   return RedirectToAction("Index", "employee");
                }
                else
                {
                    foreach(var res in result.Errors)
                    {
                        ModelState.AddModelError("password", res.Description);
                    }
                }
               

            }
            return View(newvm);
        }
        public IActionResult logout()
        {
             signin.SignOutAsync();
            return RedirectToAction("reegistr");
        }
        public async Task<IActionResult> addadmin(registeruserviewmodel newvm)
        {
            applicationuser user = new applicationuser();
            if (ModelState.IsValid)
            {
                user.UserName = newvm.username;
                user.address = newvm.address;
                user.PasswordHash = newvm.password;
                IdentityResult result = await usermanger.CreateAsync(user, newvm.password);
                if (result.Succeeded)
                {
                    await usermanger.AddToRoleAsync(user, "admin");
                    await signin.SignInAsync(user, false);
                    return RedirectToAction("Index", "employee");
                }
                else
                {
                    foreach (var res in result.Errors)
                    {
                        ModelState.AddModelError("password", res.Description);
                    }
                }


            }
            return View(newvm);
        }
    }
}
