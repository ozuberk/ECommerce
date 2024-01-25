using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult ProductsIndex()
        {
            return View();
        }
    }
}
