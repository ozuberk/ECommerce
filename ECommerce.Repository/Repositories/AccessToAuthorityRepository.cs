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
    public class AccessToAuthorityRepository : GenericRepository<AccessToAuthority>, IAccessToAuthorityRepository
    {
        public AccessToAuthorityRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<string> AccessToAuthorityAdd(int erisimAlaniId, int yetkiId, string aciklama)
        {
            try
            {
                AccessToAuthority erisimEkle = new AccessToAuthority();
                erisimEkle.AuthorityId = yetkiId;
                erisimEkle.AccessAreaId = erisimAlaniId;
                erisimEkle.Description = aciklama;
                erisimEkle.AddedDate = DateTime.Now;
                await AddAsync(erisimEkle);
                return "başarılı";
            }
            catch (Exception)
            {
                return "hata";
            }
        }

        public async Task<List<AccessToAuthority>> AccessToAuthorityList()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<string> AccessToAuthorityRemove(int erisimAlaniId, int yetkiId)
        {
            var yetkiSil = await GetFirst(y =>
            y.AccessAreaId == erisimAlaniId &&
            y.AuthorityId == yetkiId);

            //var a = await GetAllQuery(y =>
            //y.ErisimAlaniId == erisimAlaniId &&
            //y.YetkiId == yetkiId).FirstOrDefaultAsync();
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
    }
}
