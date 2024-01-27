using ECommerce.Core.ECommerceDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.IRepositories
{
    public interface ICategoriesRepository : IGenericRepository<Categories>
    {
        Task<Categories> CategoriesRemoveAsync(int id);
        Task<string> CategorieAddAsync(string kategoriAdi, string aciklama);
        Task<string> CategorieUpdateAsync(int id, string kategoriAdi, string aciklama);
        Task<List<Categories>> CategoriesListAsync();
    }
}
