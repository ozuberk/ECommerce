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
        public ProductsService(IGenericRepository<Products> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {

        }
        public Task<List<Products>> GetProductsWithCategoryAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Products> GetProductWithCategory(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
