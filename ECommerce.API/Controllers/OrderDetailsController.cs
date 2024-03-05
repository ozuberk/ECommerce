using ECommerce.Core.ECommerceDatabase;
using ECommerce.Core.IService;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class OrderDetailsController : BaseController
    {
        private readonly IOrderDetailsService _service;
        public OrderDetailsController(IOrderDetailsService orderDetailsService)
        {
            _service = orderDetailsService;
        }
        [HttpGet]
        public async Task<IActionResult> OrderDetailList()
        {
            var siparisDetay = await _service.GetAllAsync();
            return ResultAPI(siparisDetay);
        }

        [HttpPost]
        public async Task<IActionResult> OrderDetailSave(OrderDetails orderDetails)
        {
            var siparisDetay = await _service.AddAsync(orderDetails);
            return ResultAPI(siparisDetay);
        }

        [HttpPut("OrderDetailUpdate")]
        public async Task<IActionResult> OrderDetailUpdate(OrderDetails orderDetails)
        {
            var siparisDetay = await _service.GetByIdAsync(orderDetails.OrderId);

            if (siparisDetay != null)
            {
                await _service.UpdateAsync(siparisDetay);
                return ResultAPI(orderDetails);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpDelete("OrderDetailDelete/{id}")]
        public async Task<IActionResult> OrderDetailDelete(int id)
        {
            var siparisDetay = await _service.GetByIdAsync(id);

            if (siparisDetay != null)
            {
                await _service.RemoveAsync(siparisDetay);
                return Ok();
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("OrderDetailGetById/{id}")]
        public async Task<IActionResult> OrderDetailGetById(int id)
        {
            var siparisDetay = await _service.GetByIdAsync(id);

            return ResultAPI(siparisDetay);
        }
    }
}
