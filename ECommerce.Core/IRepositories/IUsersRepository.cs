using ECommerce.Core.ECommerceDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.IRepositories
{
    public interface IUsersRepository : IGenericRepository<Users>
    {
        Task<List<Users>> GetUsersWithAuthorizationsAsync();
        Task<Users> GetUsersWithAuthorizationsAsync(int kullanicilarId);

        Task<string> UsersAdd(string Adi, string Soyadi, string Resim, string KullaniciEmail, string KullaniciSifre, bool PersonelMi, int YetkiId);
        Task<string> UsersAddRange(IEnumerable<Users> kullanicilar);

        Task<string> UsersUpdate(int KullanicilarId, string Adi, string Soyadi, string Resim, string KullaniciEmail, string KullaniciSifre, bool PersonelMi, bool aktifMi, DateTime EklenmeTarihi, int YetkiId);

        Task<string> UsersRemove(int KullanicilarId);
        Task<string> UsersRemoveRange(IEnumerable<Users> kullanicilar);

        Task<List<Users>> UsersList();

        Task<List<Users>> UsersList(bool aktifMi);

        Task<Users> Login(string kullaniciAdi, string sifre);
        Task<Users> GetUsers(int kullaniciId);
    }
}
