using ECommerce.Core.ECommerceDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.IRepositories
{
    public interface ICustomersRepository : IGenericRepository<Customers>
    {
        Task<List<Customers>> GetCustomersWithOrdersAsync();
        Task<Customers> GetCustomersWithOrdersAsync(int musteriID);
        Task<List<Customers>> GetCustomersWithAddressAsync();
        Task<Customers> GetCustomersWithAddressAsync(int musteriID);
        Task<List<Customers>> GetCustomersWithUsersAsync();
        Task<Customers> GetCustomersWithUsersAsync(int musteriID);
        Task<string> CustomersAddAsync(string adi, string soyadi, string cinsiyet, string telefon, string meslek, DateTime dogumTarihi, bool aktifMi, DateTime eklenmeTarihi, DateTime guncellenmeTarihi, int kullaniciId);
        Task<string> CustomersUpdateAsync(int musteriId, string adi, string soyadi, string cinsiyet, string telefon, string meslek, DateTime dogumTarihi, bool aktifMi, DateTime eklenmeTarihi, DateTime guncellenmeTarihi, int kullaniciId);
        Task<string> CustomersRemoveAsync(int musteriId);
        Task<List<Customers>> CustomersListAsync();
        Task<List<Customers>> CustomersListAsync(bool aktifMi);
    }
}
