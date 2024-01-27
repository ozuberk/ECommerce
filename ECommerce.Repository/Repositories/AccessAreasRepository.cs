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
    public class AccessAreasRepository : GenericRepository<AccessAreas>, IAccessAreasRepository
    {
        public AccessAreasRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<string> AccessAreasAdd(string controllerAdi, string viewAdi, string aciklama)
        {
            try
            {
                AccessAreas alanEkle = new AccessAreas();
                alanEkle.ControllerName = controllerAdi;
                alanEkle.ViewName = viewAdi;
                alanEkle.Description = aciklama;
                alanEkle.Active = true;
                alanEkle.AddedDate = DateTime.Now;
                await AddAsync(alanEkle);
                return "başarılı";

            }
            catch (Exception)
            {
                return "hata";

            }
        }

        public async Task<string> AccessAreasAddRange(IEnumerable<AccessAreas> erisimAlanlari)
        {
            try
            {
                await AddRangeAsync(erisimAlanlari);
                return "başarılı";
            }
            catch (Exception)
            {
                return "hata";
            }
        }

        public async Task<List<AccessAreas>> AccessAreasList()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<List<AccessAreas>> AccessAreasList(bool aktifMi)
        {
            return await GetAllQuery(y => y.Active == aktifMi).ToListAsync();
        }

        public async Task<string> AccessAreasRemove(int erisimAlaniId)
        {
            var alanSil = await GetByIdAsync(erisimAlaniId);
            try
            {
                if (alanSil != null)
                {
                    Remove(alanSil);
                    await _appDbContext.SaveChangesAsync();
                    return "başarılı";
                }
                else
                {
                    return "alan bulunamadı";
                }

            }
            catch (Exception)
            {
                return "hata";
            }
        }

        public async Task<string> AccessAreasRemoveRange(IEnumerable<AccessAreas> erisimAlanlari)
        {
            try
            {
                RemoveRange(erisimAlanlari);
                return "başarılı";
            }
            catch (Exception)
            {
                return "hata";
            }
        }

        public async Task<string> AccessAreasUpdate(int erisimAlaniId, string controllerAdi, string viewAdi, string aciklama, bool aktifMi, DateTime eklemeTarihi)
        {
            var alanGuncelle = await GetByIdAsync(erisimAlaniId);
            try
            {
                alanGuncelle.ControllerName = controllerAdi;
                alanGuncelle.ViewName = viewAdi;
                alanGuncelle.Description = aciklama;
                alanGuncelle.AddedDate = eklemeTarihi;
                alanGuncelle.Active = aktifMi;
                alanGuncelle.UpdatedDate = DateTime.Now;
                return "başarılı";
            }
            catch (Exception)
            {
                return "hata";

            }
        }
    }
}
