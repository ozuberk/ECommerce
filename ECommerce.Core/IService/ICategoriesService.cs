using ECommerce.Core.ECommerceDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.IService
{
    public interface ICategoriesService : IService<Categories>
    {
        Task<List<Categories>> GetCategoriesWithProducts();
        Task<Categories> GetCategoriesWithProducts(int kategorilerId);
        IQueryable<Categories> CategoriesList();
        Task<object> CategoriesRemoveAsync(int id);
    }
}
