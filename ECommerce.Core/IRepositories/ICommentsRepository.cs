using ECommerce.Core.ECommerceDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.IRepositories
{
    public interface ICommentsRepository : IGenericRepository<Comments>
    {
        Task<List<Comments>> GetYorumlarWithUrunlerAsync();
        Task<Comments> GetYorumlarWithUrunlerAsync(int urunId);
        Task<List<Comments>> GetYorumlarWithKullanicilarAsync();
        Task<Comments> GetYorumlarWithKullanicilarAsync(int kullaniciId);
    }
}
