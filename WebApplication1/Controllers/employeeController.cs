using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class employeeController : Controller
    {
        entities contexto = new entities();
       [Authorize]
        public IActionResult Index()
        {
            List<employe> emp = contexto.employes.ToList();

            return View(emp);
        }
        public IActionResult modify(int id)
        {
            employe oldemp = contexto.employes.FirstOrDefault(e => e.Id == id);
            ViewData["dept"] = contexto.departments.ToList();

            return View(oldemp);

        }
        public IActionResult saveedit(int id, employe newemp)
        {
            employe oldemp = contexto.employes.FirstOrDefault(e => e.Id == id);
            if (newemp.Name != null)
            {
                oldemp.Name = newemp.Name;
                oldemp.salary = newemp.salary;
                oldemp.adreess = newemp.adreess;
                oldemp.dept_id = newemp.dept_id;
                oldemp.iamge = newemp.iamge;
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("modify", newemp);
            }
        }
        public IActionResult nweemp()
        {
            ViewData["dept"] = contexto.departments.ToList();
            return View();
        }
        public IActionResult savenew(employe emp)
        {
            if (emp.Name != null)
            {
                contexto.employes.Add(emp);
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["dept"] = contexto.departments.ToList();
                return View("nweemp", emp);
            }
        }

    }
}
