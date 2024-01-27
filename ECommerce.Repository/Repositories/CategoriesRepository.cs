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
    public class CategoriesRepository : GenericRepository<Categories>, ICategoriesRepository
    {
        public CategoriesRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<string> CategorieAddAsync(string kategoriAdi, string aciklama)
        {
            try
            {
                Categories kategoriler = new Categories();
                kategoriler.CategoryName = kategoriAdi;
                kategoriler.Description = aciklama;
                await AddAsync(kategoriler);
                return "İşlem Başarılı";
            }
            catch (Exception ex)
            {
                return "İşlem sırasında hata " + ex + "oluştu";
            }
        }

        public async Task<List<Categories>> CategoriesListAsync()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<Categories> CategoriesRemoveAsync(int id)
        {
            var kategoriSil = await GetByIdAsync(id);
            if (kategoriSil != null)
            {
                kategoriSil.Active = false;
                await _appDbContext.SaveChangesAsync();
            }

            return kategoriSil;
        }

        public async Task<string> CategorieUpdateAsync(int id, string kategoriAdi, string aciklama)
        {
            var kategoriGuncelle = await GetByIdAsync(id);
            try
            {
                kategoriGuncelle.CategoryName = kategoriAdi;
                kategoriGuncelle.Description = aciklama;
                return "İşlem Başarılı";
            }
            catch (Exception ex)
            {
                return "İşlem sırasında hata " + ex + "oluştu";
            }
        }
    }
}
