using ECommerce.Core.ECommerceDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.IService
{
    public interface IProductsService :IService<Products>
    {
        Task<List<Products>> GetProductsWithCategoryAsync();
        Task<Products> GetProductWithCategory(int productId);
    }
}
