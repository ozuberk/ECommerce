using ECommerce.Core.ECommerceDatabase;
using ECommerce.Core.IService;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly IService<Categories> _service;
        public CategoriesController(IService<Categories> service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var category = await _service.GetAllAsync();
            return Ok(category);
        }
    }
}
