using ECommerce.Core.ECommerceDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.IRepositories
{
    public interface IAuthorizationsRepository : IGenericRepository<Authorizations>
    {
        Task<int> AuthorizationsCount(int yetkiId);
        Task<string> AuthorizationsAdd(string yetkiAdi);
        Task<string> AuthorizationsUpdate(int yetkiId, string yetkiAdi, bool aktifMi, DateTime eklemeTarihi, DateTime guncellemeTarihi);
        Task<string> AuthorizationsRemove(int yetkiId);
        Task<List<Authorizations>> AuthorizationsList();
        Task<List<Authorizations>> AuthorizationsList(bool aktifMi);
    }
}
