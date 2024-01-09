using ECommerce.Core.ECommerceDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.IRepositories
{
    public interface IProductsRepository : IGenericRepository<Products>
    {
        Task<List<Products>> GetProductsWithCategoryAsync();
        Task<Products> GetProductWithCategoryAsync(int productId);
    }
}
