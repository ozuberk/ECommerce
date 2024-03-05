using ECommerce.Core.ECommerceDatabase;
using ECommerce.Core.IService;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly IUsersService _service;
        public UsersController(IUsersService usersService)
        {
            _service = usersService;
        }
        [HttpGet]
        public async Task<IActionResult> UsersIndex()
        {
            var kullanici = await _service.GetAllAsync();
            return ResultAPI(kullanici);
        }


        [HttpPost]
        public async Task<IActionResult> UserSave(Users user)
        {
            var kullanici = await _service.AddAsync(user);
            return ResultAPI(kullanici);
        }

        [HttpPut("UserUpdate")]
        public async Task<IActionResult> UserUpdate(Users user)
        {
            var kullanici = await _service.GetByIdAsync(user.ID);

            if (kullanici != null)
            {
                await _service.UpdateAsync(kullanici);
                return ResultAPI(user);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpDelete("UserDelete/{id}")]
        public async Task<IActionResult> UserDelete(int id)
        {
            var kullanici = await _service.GetByIdAsync(id);

            if (kullanici != null)
            {
                await _service.RemoveAsync(kullanici);
                return Ok();
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("UserGetById/{id}")]
        public async Task<IActionResult> UserGetById(int id)
        {
            var kullanici = await _service.GetByIdAsync(id);

            return ResultAPI(kullanici);
        }
    }
}
