using ECommerce.Core.ECommerceDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.IRepositories
{
    public interface IPicturesRepository : IGenericRepository<Pictures>
    {
        Task<List<Pictures>> GetFotografWithUrunAsync();

        Task<Pictures> GetFotografWithUrunAsync(int fotografId);

        Task<string> FotografEkleAsync(string fotografYolu, string fotografAciklamasi, byte fotografSirasi, int urunId, bool aktifMi, DateTime eklemeTarihi, DateTime guncellemeTarihi);

        Task<string> FotografGuncelleAsync(int fotografId, string fotografYolu, string fotografAciklamasi, byte fotografSirasi, int urunId, bool aktifMi, DateTime eklemeTarihi, DateTime guncellemeTarihi);

        Task<string> FotografSilAsync(int fotografId);

        Task<List<Pictures>> FotografListesiAsync();

        Task<List<Pictures>> FotografListesiAsync(bool aktifMi);
    }
}
