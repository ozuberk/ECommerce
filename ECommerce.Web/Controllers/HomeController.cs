using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult HomeIndex()
        {
            return View();
        }
    }
}
