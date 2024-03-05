using ECommerce.Core.ECommerceDatabase;
using ECommerce.Core.IService;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        private readonly ICategoriesService _service;
        public CategoriesController(ICategoriesService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> CategoriesIndex()
        {
            var category = await _service.GetAllAsync();
            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> CategoriesSave(Categories category)
        {
            var kategoriKaydet = await _service.AddAsync(category);
            return ResultAPI(kategoriKaydet);
        }
        [HttpPut("CategoryUpdate")]
        public async Task<IActionResult> CategoriesUpdate(Categories category)
        {
            var kategori = await _service.GetByIdAsync(category.ID);

            if (kategori != null)
            {
                await _service.UpdateAsync(kategori);
                return ResultAPI(kategori);
            }
            else
            {
                return NoContent();
            }
        }
        [HttpDelete("CategoryDelete/{id}")]
        public async Task<IActionResult> CategoriesDelete(int id)
        {
            var kategori = await _service.GetByIdAsync(id);

            if (kategori != null)
            {
                await _service.RemoveAsync(kategori);
                return Ok();
            }
            else
            {
                return NoContent();
            }
        }
        [HttpGet("GetCategoryById/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var kategori = await _service.GetByIdAsync(id);

            return ResultAPI(kategori);
        }
        [HttpGet("GetCategoryWithProduct")]
        public async Task<IActionResult> GetCategoryWithProduct()
        {
            var kategoriler = await _service.GetCategoriesWithProducts();

            return ResultAPI(kategoriler);
        }
    }
}
