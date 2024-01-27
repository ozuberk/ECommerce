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
    public class DistrictsRepository : GenericRepository<Districts>, IDistrictsRepository
    {
        public DistrictsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Districts>> DistrictsListAsync()
        {
            return await GetAll().ToListAsync();
        }
    }
}
