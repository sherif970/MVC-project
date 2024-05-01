using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class departmentController : Controller
    {
        entities dept ; //= new entities();
        public departmentController(entities db) 
        {
            dept = db;
        }

        public IActionResult getall()
        {
            List<department> getdept = dept.departments.ToList();
            return View(getdept);
        }
        public IActionResult neww()
        {
            return View(new department());
        }
       public IActionResult savenew(department depto)
        {
            if (depto.Name != null && depto.managername!=null )
            {
                dept.departments.Add(depto);
                dept.SaveChanges();
                return RedirectToAction("getall", depto);
            }
            else { return View("neww" , depto); }
        }


    }
}
