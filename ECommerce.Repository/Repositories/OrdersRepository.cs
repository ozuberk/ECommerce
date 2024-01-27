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
    public class OrdersRepository : GenericRepository<Orders>, IOrdersRepository
    {
        public OrdersRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Orders>> GetOrdersMadeTodayAsync(DateTime siparisTarihi)
        {
            return await GetAllQuery(s => s.AddedDate == siparisTarihi).ToListAsync();
        }

        public async Task<List<Orders>> GetOrdersWithCustomerAsync(Customers musteriID)
        {
            return await GetAllQuery(m => m.CustomerId == musteriID.ID).Include(m => m.Customers).ToListAsync();
        }

        public async Task<List<Orders>> GetOrdersWithCustomersAsync()
        {
            return await _appDbContext.Orders.Include(s => s.Customers).ToListAsync();
        }

        public async Task<List<Orders>> GetOrdersWithUsersAsync(Users kullaniciID)
        {
            return await GetAllQuery(k => k.UserId == kullaniciID.ID).Include(m => m.Users).ToListAsync();
        }
    }
}
