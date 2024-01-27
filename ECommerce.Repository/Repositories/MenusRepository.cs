using ECommerce.Core.ECommerceDatabase;
using ECommerce.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Repositories
{
    public class MenusRepository : GenericRepository<Menus>, IMenusRepository
    {
        public MenusRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Menus>> GetMenusWithAccessAreasAsync()
        {
            return await _appDbContext.Menus.Include(m => m.AccessAreas).ToListAsync();
        }

        public async Task<Menus> GetMenusWithAccessAreasAsync(int menuId)
        {
            return await GetAllQuery(m => m.ID == menuId).Include(m => m.AccessAreas).FirstOrDefaultAsync();
        }

        public async Task<List<Menus>> GetMenusWithTopMenusAsync()
        {
            return await _appDbContext.Menus.Include(m => m.TopMenu).ToListAsync();
        }

        public async Task<Menus> GetMenusWithTopMenusAsync(int menuId)
        {
            return await GetAllQuery(m => m.ID == menuId).Include(m => m.TopMenu).FirstOrDefaultAsync();
        }

        public async Task<string> MenusAddAsync(string menuAdi, int ustMenuId, int menuSirasi, string aciklama, int erisimAlaniId, bool aktifMi, DateTime eklemeTarihi, DateTime guncellemeTarihi, int kullaniciId)
        {
            try
            {

                Menus menu = new Menus();
                menu.MenuName = menuAdi;
                menu.TopMenuId = ustMenuId;
                menu.MenuOrder = menuSirasi;
                menu.Description = aciklama;
                menu.AccessAreaId = erisimAlaniId;
                menu.Active = aktifMi;
                menu.AddedDate = eklemeTarihi;
                menu.UpdatedDate = guncellemeTarihi;
                menu.UserId = kullaniciId;
                await AddAsync(menu); return "Ekleme başarılı";
            }
            catch (Exception)
            {
                return "Ekleme esnasında hata oluştu";
            };
        }

        public async Task<List<Menus>> MenusListAsync()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<List<Menus>> MenusListAsync(bool aktifMi)
        {
            return await GetAllQuery(m => m.Active == aktifMi).ToListAsync();
        }

        public async Task<string> MenusRemoveAsync(int menuId)
        {
            var menuSil = await GetByIdAsync(menuId);
            try
            {
                menuSil.Active = false;
                return "Silme başarılı";
            }
            catch (Exception)
            {
                return "Silme esnasında hata oluştu";
            }
        }

        public async Task<string> MenusUpdateAsync(int menuId, string menuAdi, int ustMenuId, int menuSirasi, string aciklama, int erisimAlaniId, bool aktifMi, DateTime eklemeTarihi, DateTime guncellemeTarihi, int kullaniciId)
        {
            var menuBul = await GetByIdAsync(menuId);
            try
            {
                menuBul.MenuName = menuAdi;
                menuBul.TopMenuId = ustMenuId;
                menuBul.MenuOrder = menuSirasi;
                menuBul.Description = aciklama;
                menuBul.AccessAreaId = erisimAlaniId;
                menuBul.Active = aktifMi;
                menuBul.AddedDate = eklemeTarihi;
                menuBul.UpdatedDate = guncellemeTarihi;
                menuBul.UserId = kullaniciId;
                return "Güncelleme başarılı";
            }
            catch (Exception)
            {
                return "Güncelleme esnasında hata oluştu";
            }
        }
    }
}
