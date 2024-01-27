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
    public class AuthorizationsRepository : GenericRepository<Authorizations>, IAuthorizationsRepository
    {
        public AuthorizationsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<string> AuthorizationsAdd(string yetkiAdi)
        {
            try
            {
                Authorizations yetkiEkle = new Authorizations();
                yetkiEkle.AuthorityName = yetkiAdi;
                yetkiEkle.Active = true;
                yetkiEkle.AddedDate = DateTime.Now;
                await AddAsync(yetkiEkle);
                return "başarılı";

            }
            catch (Exception)
            {
                return "hata";
            }
        }

        public async Task<int> AuthorizationsCount(int yetkiId)
        {
            return await GetAllQuery(y => y.ID == yetkiId).CountAsync();
        }

        public async Task<List<Authorizations>> AuthorizationsList()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<List<Authorizations>> AuthorizationsList(bool aktifMi)
        {
            return await GetAllQuery(y => y.Active == aktifMi).ToListAsync();
        }

        public async Task<string> AuthorizationsRemove(int yetkiId)
        {
            var yetkiSil = await GetByIdAsync(yetkiId);
            try
            {
                if (yetkiSil != null)
                {
                    Remove(yetkiSil);
                    await _appDbContext.SaveChangesAsync();
                    return "başarılı";
                }
                else
                {
                    return "yetki bulunamadı";
                }

            }
            catch (Exception)
            {
                return "hata";
            }
        }

        public async Task<string> AuthorizationsUpdate(int yetkiId, string yetkiAdi, bool aktifMi, DateTime eklemeTarihi, DateTime guncellemeTarihi)
        {
            var yetkiGuncelle = await GetByIdAsync(yetkiId);
            try
            {
                yetkiGuncelle.AuthorityName = yetkiAdi;
                yetkiGuncelle.Active = aktifMi;
                yetkiGuncelle.AddedDate = eklemeTarihi;
                yetkiGuncelle.UpdatedDate = DateTime.Now;
                return "başarılı";
            }
            catch (Exception)
            {
                return "hata";
            }
        }
    }
}
