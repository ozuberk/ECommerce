using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Areas.AdminPanel.Controllers
{
    public class AdminHomeController : Controller
    {
        public IActionResult AdminHomeIndex()
        {
            return View();
        }
    }
}
