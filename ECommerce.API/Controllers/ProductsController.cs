using AutoMapper;
using ECommerce.Core.DTO;
using ECommerce.Core.ECommerceDatabase;
using ECommerce.Core.IService;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IService<Products> _service;
        private readonly IMapper _mapper;
        public ProductsController(IService<Products> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet("Products_List")]
        public async Task<IActionResult> ProductsIndex()
        {
            var products = await _service.GetAllAsync();
            var productsDTO = _mapper.Map<List<ProductsDTO>>(products);
            return Ok(productsDTO);
        }
        [HttpPost("Product_Save")]
        public async Task<IActionResult> ProductSave(ProductsDTO productsDTO)
        {
            var mapProducts = _mapper.Map<Products>(productsDTO);
            var productSave = await _service.AddAsync(mapProducts);
            var mapAdd = _mapper.Map<ProductsDTO>(productSave);

            return Ok(mapAdd);
        }
    }
}
