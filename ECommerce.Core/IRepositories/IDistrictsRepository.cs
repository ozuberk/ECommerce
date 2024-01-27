using ECommerce.Core.ECommerceDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.IRepositories
{
    public interface IDistrictsRepository :IGenericRepository<Districts>
    {
        Task<List<Districts>> DistrictsListAsync();

    }
}
