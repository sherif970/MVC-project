using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.view_models;

namespace WebApplication1.Controllers
{
    public class roleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
       
        public roleController(RoleManager<IdentityRole> roleManager  ) 
        {
            this.roleManager = roleManager;
            
        }
        [Authorize(Roles ="admin")]
      
        public async Task<IActionResult> addrole(rolemodel newrole)
        {
            if (ModelState.IsValid== true )
            {
                IdentityRole identityRole = new IdentityRole();
                identityRole.Name = newrole.name;
             IdentityResult result = await roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {

                    return Content("the role added");
                }
                else
                {
                    foreach (var role in result.Errors)
                    {
                        ModelState.AddModelError("", role.Description);
                    }
                }
            }
            return View(newrole);
        }
    }
}
