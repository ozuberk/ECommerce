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
        Task<List<Pictures>> GetPicturesWithProductAsync();

        Task<Pictures> GetPicturesWithProductAsync(int fotografId);

        Task<string> PicturesAddAsync(string fotografYolu, string fotografAciklamasi, byte fotografSirasi, int urunId, bool aktifMi, DateTime eklemeTarihi, DateTime guncellemeTarihi);

        Task<string> PicturesUpdateAsync(int fotografId, string fotografYolu, string fotografAciklamasi, byte fotografSirasi, int urunId, bool aktifMi, DateTime eklemeTarihi, DateTime guncellemeTarihi);

        Task<string> PicturesRemoveAsync(int fotografId);

        Task<List<Pictures>> PicturesListAsync();

        Task<List<Pictures>> PicturesListAsync(bool aktifMi);
    }
}
