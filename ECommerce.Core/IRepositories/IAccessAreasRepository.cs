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
        Task<string> AccessAreasAdd(string controllerAdi, string viewAdi, string aciklama);
        Task<string> AccessAreasAddRange(IEnumerable<AccessAreas> erisimAlanlari);
        Task<string> AccessAreasUpdate(int erisimAlaniId, string controllerAdi, string viewAdi, string aciklama, bool aktifMi, DateTime eklemeTarihi);
        Task<string> AccessAreasRemove(int erisimAlaniId);
        Task<string> AccessAreasRemoveRange(IEnumerable<AccessAreas> erisimAlanlari);
        Task<List<AccessAreas>> AccessAreasList();
        Task<List<AccessAreas>> AccessAreasList(bool aktifMi);
    }
}
