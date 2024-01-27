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
    public class CitiesRepository : GenericRepository<Cities>, ICitiesRepository
    {
        public CitiesRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Districts>> GetIllerWithIlceler(int ilId)
        {
            var ilceler = await _appDbContext.Cities.Where(il => il.CityCode == ilId).SelectMany(il => il.Districts).ToListAsync();
            return ilceler;
        }

        public async Task<List<Cities>> IllerListele()
        {
            return await GetAll().ToListAsync();
        }
    }
}
