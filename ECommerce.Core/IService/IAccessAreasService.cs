using ECommerce.Core.ECommerceDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.IService
{
    public interface IAccessAreasService : IService<AccessAreas>
    {
        Task<List<AccessAreas>> GetAccessAreasWithAccessIdAsync(int yetkiId);
        Task<IEnumerable<AccessAreas>> GetAccessArea();
        Task<string> AccessAreaRemoveAsync(int erisimAlanId);
    }
}
