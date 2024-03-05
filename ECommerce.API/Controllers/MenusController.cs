using ECommerce.Core.ECommerceDatabase;
using ECommerce.Core.IService;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class MenusController : BaseController
    {
        private readonly IMenusService _service;
        public MenusController(IMenusService menusService)
        {
            _service = menusService;
        }
        [HttpGet]
        public async Task<IActionResult> MenusIndex()
        {
            var menuler = await _service.GetAllAsync();
            return ResultAPI(menuler);
        }

        [HttpPost]
        public async Task<IActionResult> MenulerSave(Menus menu)
        {
            var menuSave = await _service.AddAsync(menu);
            return ResultAPI(menuSave);
        }

        [HttpPut("MenusUpdate")]
        public async Task<IActionResult> MenusUpdate(Menus menu)
        {
            var getMenu = await _service.GetByIdAsync(menu.ID);

            if (getMenu != null)
            {
                await _service.UpdateAsync(getMenu);
                return ResultAPI(menu);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpDelete("MenusRemove/{id}")]
        public async Task<IActionResult> MenusRemove(int id)
        {
            var getMenu = await _service.GetByIdAsync(id);

            if (getMenu != null)
            {
                await _service.RemoveAsync(getMenu);
                return Ok();
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("MenuGetById/{id}")]
        public async Task<IActionResult> MenuGetById(int id)
        {
            var getMenu = await _service.GetByIdAsync(id);

            return ResultAPI(getMenu);
        }
    }
}
