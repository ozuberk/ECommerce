using ECommerce.Core.ECommerceDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.IRepositories
{
    public interface IMenusRepository : IGenericRepository<Menus>
    {

        Task<List<Menus>> GetMenusWithAccessAreasAsync();
        Task<Menus> GetMenusWithAccessAreasAsync(int menuId);
        Task<List<Menus>> GetMenusWithTopMenusAsync();
        Task<Menus> GetMenusWithTopMenusAsync(int menuId);
        Task<string> MenusAddAsync(string menuAdi, int ustMenuId, int menuSirasi, string aciklama, int erisimAlaniId, bool aktifMi, DateTime eklemeTarihi, DateTime guncellemeTarihi, int kullaniciId);
        Task<string> MenusUpdateAsync(int menuId, string menuAdi, int ustMenuId, int menuSirasi, string aciklama, int erisimAlaniId, bool aktifMi, DateTime eklemeTarihi, DateTime guncellemeTarihi, int kullaniciId);
        Task<string> MenusRemoveAsync(int menuId);
        Task<List<Menus>> MenusListAsync();
        Task<List<Menus>> MenusListAsync(bool aktifMi);
    }
}
