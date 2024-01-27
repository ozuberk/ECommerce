using ECommerce.Core.ECommerceDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.IRepositories
{
    public interface IAccessToAuthorityRepository : IGenericRepository<AccessToAuthority>
    {

        Task<string> AccessToAuthorityAdd(int erisimAlaniId, int yetkiId, string aciklama);
        Task<string> AccessToAuthorityRemove(int erisimAlaniId, int yetkiId);
        Task<List<AccessToAuthority>> AccessToAuthorityList();
    }
}
