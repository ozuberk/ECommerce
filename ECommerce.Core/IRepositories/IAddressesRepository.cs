using ECommerce.Core.ECommerceDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.IRepositories
{
    public interface IAddressesRepository : IGenericRepository<Addresses>
    {
        Task<List<Addresses>> AddressesListAsync();
        Task<List<Addresses>> GetAddressesWithDistrictsAsync(int districtCode);
        Task<List<Addresses>> GetAddressesWithDistrictsAsync();
        Task<List<Addresses>> GetAddressesWithCustomersAsync();
        Task<Addresses> GetAddressesWithCustomersAsync(int customerId);
        Task<Addresses> AddressesRemoveAsync(int id);
    }
}
