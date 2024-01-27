using ECommerce.Core.ECommerceDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.IRepositories
{
    public interface IOrderDetailsRepository : IGenericRepository<OrderDetails>
    {

        Task<List<OrderDetails>> GetOrderDetailsWithProductsAsync(int urunID);
        Task<List<OrderDetails>> GetOrderDetailsWithOrdersAsync(int siparisID);
        Task<List<OrderDetails>> GetOrderDetailsWithPriceAsync(int siparisID);
    }
}
