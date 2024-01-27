using AutoMapper;
using ECommerce.Core.ECommerceDatabase;
using ECommerce.Core.IRepositories;
using ECommerce.Core.IService;
using ECommerce.Core.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.Services
{
    public class ProductsService : Service<Products>, IProductsService
    {
        readonly IProductsRepository _urunlerRepository;
        readonly IMapper _mapper;
        public ProductsService(IGenericRepository<Products> repository, IUnitOfWork unitOfWork, IMapper mapper, IProductsRepository productsRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _urunlerRepository = productsRepository;
        }
        public async Task<List<Products>> GetProductsWithCategoryAsync()
        {
            var urunVeKategoriList = await _urunlerRepository.GetProductsWithCategoryAsync();
            return urunVeKategoriList;

        }

        public async Task<Products> GetProductWithCategory(int productId)
        {
            var urunVeKategori = await _urunlerRepository.GetProductWithCategoryAsync(productId);
            return urunVeKategori;
        }
    }
}
