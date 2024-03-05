using AutoMapper;
using ECommerce.Core.DTO;
using ECommerce.Core.ECommerceDatabase;
using ECommerce.Core.IService;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    public class ProductsController : BaseController
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

        [HttpPut("Product_Update")]
        public async Task<IActionResult> ProductUpdate(Products product)
        {
            var urun = await _service.GetByIdAsync(product.ID);
            if (urun != null)
            {
                await _service.UpdateAsync(product);
                return ResultAPI(product);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpDelete("Product_Delete/{id}")]
        public async Task<IActionResult> ProductDelete(int id)
        {
            var product = await _service.GetByIdAsync(id);

            if (product != null)
            {
                await _service.RemoveAsync(product);
                return Ok();
            }
            else
            {
                return NoContent();
            }
        }


        [HttpGet("ProductGetById/{id}")]
        public async Task<IActionResult> ProductGetById(int id)
        {
            var product = await _service.GetByIdAsync(id);

            return ResultAPI(product);
        }
    }
}
