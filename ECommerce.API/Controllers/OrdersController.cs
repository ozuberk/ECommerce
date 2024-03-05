using ECommerce.Core.ECommerceDatabase;
using ECommerce.Core.IService;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class OrdersController : BaseController
    {
        private readonly IOrdersService _service;
        public OrdersController(IOrdersService ordersService)
        {
            _service = ordersService;
        }

        [HttpGet]
        public async Task<IActionResult> OrdersList()
        {
            var siparis = await _service.GetAllAsync();
            return ResultAPI(siparis);
        }

        [HttpPost]
        public async Task<IActionResult> OrderSave(Orders order)
        {
            var siparis = await _service.AddAsync(order);
            return ResultAPI(siparis);
        }

        [HttpPut("OrderUpdate")]
        public async Task<IActionResult> OrderUpdate(Orders order)
        {
            var siparis = await _service.GetByIdAsync(order.ID);

            if (siparis != null)
            {
                await _service.UpdateAsync(siparis);
                return ResultAPI(siparis);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpDelete("OrderDelete/{id}")]
        public async Task<IActionResult> OrderDelete(int id)
        {
            var siparis = await _service.GetByIdAsync(id);

            if (siparis != null)
            {
                await _service.RemoveAsync(siparis);
                return Ok();
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("OrderGetById/{id}")]
        public async Task<IActionResult> OrderGetById(int id)
        {
            var siparis = await _service.GetByIdAsync(id);

            return ResultAPI(siparis);
        }
    }
}
