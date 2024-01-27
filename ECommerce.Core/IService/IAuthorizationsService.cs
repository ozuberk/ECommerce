using ECommerce.Core.ECommerceDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.IService
{
    public interface IAuthorizationsService : IService<Authorizations>
    {
        Task<List<Authorizations>> GetAuthorizationsWithAccessAreaIdAsync(int erisimAlanId);
        Task<List<Authorizations>> GetAuthorizations();
        Task<string> AuthorizationsRemoveAsync(int yetkiId);
    }
}
