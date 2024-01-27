using ECommerce.Core.ECommerceDatabase;
using ECommerce.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Repositories
{
    public class AddressesRepository : GenericRepository<Addresses>, IAddressesRepository
    {
        public AddressesRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Addresses>> AddressesListAsync()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<Addresses> AddressesRemoveAsync(int id)
        {
            var adresSil = await GetByIdAsync(id);
            if (adresSil != null)
            {
                adresSil.Active = false;
                await _appDbContext.SaveChangesAsync();
            }

            return adresSil;
        }

        public async Task<List<Addresses>> GetAddressesWithCustomersAsync()
        {
            return await _appDbContext.Addresses.Include(k => k.Customers).ToListAsync();
        }

        public async Task<Addresses> GetAddressesWithCustomersAsync(int customerId)
        {
            return await _appDbContext.Addresses.Include(k => k.Customers).Where(x => x.CustomerId == customerId).FirstOrDefaultAsync();
        }

        public async Task<List<Addresses>> GetAddressesWithDistrictsAsync(int districtCode)
        {
            return await _appDbContext.Addresses.Include(x => x.Districts).ThenInclude(ilce => ilce.Cities).Where(a => a.DistrictCode == districtCode).ToListAsync();
        }

        public async Task<List<Addresses>> GetAddressesWithDistrictsAsync()
        {
            return await _appDbContext.Addresses.Include(k => k.Districts).ThenInclude(ilce => ilce.Cities).ToListAsync();
        }
    }
}
