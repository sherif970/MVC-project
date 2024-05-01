using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class productController : Controller
    {
        productlist productlist = new productlist();
        public IActionResult getproduct(int id )
        {
            
            product pro = productlist.getbyid(id);
            return View("getproduct",pro);

        }
        public IActionResult getall()
        {
            List<product> list = productlist.getall();
            return View("getall", list);
        }
    }
}
