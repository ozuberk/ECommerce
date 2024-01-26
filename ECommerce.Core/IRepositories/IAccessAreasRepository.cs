using ECommerce.Core.ECommerceDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.IRepositories
{
    public interface IAccessAreasRepository : IGenericRepository<AccessAreas>
    {
        Task<string> ErisimAlaniEkle(string controllerAdi, string viewAdi, string aciklama);
        Task<string> TopluErisimAlaniEkle(IEnumerable<AccessAreas> erisimAlanlari);
        Task<string> ErisimAlaniGuncelle(int erisimAlaniId, string controllerAdi, string viewAdi, string aciklama, bool aktifMi, DateTime eklemeTarihi);
        Task<string> ErisimAlaniSil(int erisimAlaniId);
        Task<string> TopluErisimAlaniSil(IEnumerable<AccessAreas> erisimAlanlari);
        Task<List<AccessAreas>> ErisimAlaniListesi();
        Task<List<AccessAreas>> ErisimAlaniListesi(bool aktifMi);
    }
}
