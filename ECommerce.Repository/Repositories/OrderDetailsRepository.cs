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
    public class OrderDetailsRepository : GenericRepository<OrderDetails>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<OrderDetails>> GetOrderDetailsWithOrdersAsync(int siparisID)
        {
            return await GetAllQuery(s => s.OrderId == siparisID).Include(s => s.Orders).ToListAsync();
        }

        public Task<List<OrderDetails>> GetOrderDetailsWithPriceAsync(int siparisID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderDetails>> GetOrderDetailsWithProductsAsync(int urunID)
        {
            return await GetAllQuery(s => s.ProductId == urunID).Include(s => s.Products).ToListAsync();
        }
    }
}
