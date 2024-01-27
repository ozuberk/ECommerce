using ECommerce.Core.ECommerceDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.IRepositories
{
    public interface IOrdersRepository : IGenericRepository<Orders>
    {
        Task<List<Orders>> GetOrdersMadeTodayAsync(DateTime siparisTarihi);
        Task<List<Orders>> GetOrdersWithUsersAsync(Users kullaniciID);
        Task<List<Orders>> GetOrdersWithCustomerAsync(Customers musteriID);
        Task<List<Orders>> GetOrdersWithCustomersAsync();
    }
}
