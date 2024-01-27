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
    public class PicturesRepository : GenericRepository<Pictures>, IPicturesRepository
    {
        public PicturesRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Pictures>> GetPicturesWithProductAsync()
        {
            return await _appDbContext.Pictures.Include(f => f.Products).ToListAsync();
        }

        public async Task<Pictures> GetPicturesWithProductAsync(int fotografId)
        {
            return await GetAllQuery(f => f.ID == fotografId).Include(f => f.Products).FirstOrDefaultAsync();
        }

        public async Task<string> PicturesAddAsync(string fotografYolu, string fotografAciklamasi, byte fotografSirasi, int urunId, bool aktifMi, DateTime eklemeTarihi, DateTime guncellemeTarihi)
        {
            try
            {
                Pictures fotograf = new();
                fotograf.PicturePath = fotografYolu;
                fotograf.PictureDescription = fotografAciklamasi;
                fotograf.PictureOrder = fotografSirasi;
                fotograf.ProductId = urunId;
                fotograf.Active = aktifMi;
                fotograf.AddedDate = eklemeTarihi;
                fotograf.UpdatedDate = guncellemeTarihi;

                await AddAsync(fotograf);

                return "Ekleme başarılı.";
            }
            catch (Exception)
            {
                return "Ekleme esnasında hata oluştu.";
            }
        }

        public async Task<List<Pictures>> PicturesListAsync()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<List<Pictures>> PicturesListAsync(bool aktifMi)
        {
            return await GetAllQuery(f => f.Active == aktifMi).ToListAsync();
        }

        public async Task<string> PicturesRemoveAsync(int fotografId)
        {
            var fotografSil = await GetByIdAsync(fotografId);

            try
            {
                fotografSil.Active = false;

                return "Silme başarılı.";
            }
            catch (Exception)
            {
                return "Silme esnasında hata oluştu.";
            }
        }

        public async Task<string> PicturesUpdateAsync(int fotografId, string fotografYolu, string fotografAciklamasi, byte fotografSirasi, int urunId, bool aktifMi, DateTime eklemeTarihi, DateTime guncellemeTarihi)
        {
            var fotografBul = await GetByIdAsync(fotografId);

            try
            {
                fotografBul.PicturePath = fotografYolu;
                fotografBul.PictureDescription = fotografAciklamasi;
                fotografBul.PictureOrder = fotografSirasi;
                fotografBul.ProductId = urunId;
                fotografBul.Active = aktifMi;
                fotografBul.AddedDate = eklemeTarihi;
                fotografBul.UpdatedDate = guncellemeTarihi;

                return "Güncelleme başarılı.";
            }
            catch (Exception)
            {
                return "Güncelleme esnasında hata oluştu.";
            }
        }
    }
}
