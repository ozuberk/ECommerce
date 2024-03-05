using ECommerce.Core.ECommerceDatabase;
using ECommerce.Core.IService;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AuthorizationsController : BaseController
    {
        private readonly IAuthorizationsService _service;
        public AuthorizationsController(IAuthorizationsService authorizationsService)
        {
            _service = authorizationsService;
        }
        [HttpGet]
        public async Task<IActionResult> AuthorizationsIndex()
        {
            var yetki = await _service.GetAllAsync();
            return ResultAPI(yetki);
        }

        [HttpPost]
        public async Task<IActionResult> AuthorizationSave(Authorizations authorization)
        {
            var yetki = await _service.AddAsync(authorization);
            return ResultAPI(yetki);
        }

        [HttpPut("AuthorizationUpdate")]
        public async Task<IActionResult> AuthorizationUpdate(Authorizations authorization)
        {
            var yetki = await _service.GetByIdAsync(authorization.ID);

            if (yetki != null)
            {
                await _service.UpdateAsync(yetki);
                return ResultAPI(authorization);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpDelete("AuthorizationDelete/{id}")]
        public async Task<IActionResult> AuthorizationDelete(int id)
        {
            var yetki = await _service.GetByIdAsync(id);

            if (yetki != null)
            {
                await _service.RemoveAsync(yetki);
                return Ok();
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("AuthorizationGetById/{id}")]
        public async Task<IActionResult> AuthorizationGetById(int id)
        {
            var yetki = await _service.GetByIdAsync(id);

            return ResultAPI(yetki);
        }
    }
}
