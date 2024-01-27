using ECommerce.Core.ECommerceDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.IRepositories
{
    public interface IEmployeesRepository : IGenericRepository<Employees>
    {
        Task<List<Employees>> GetEmployeesWithUsersAsync();
        Task<Employees> GetEmployeesWithUsersAsync(int personellerId);
        Task<string> EmployeeAdd(string PersonelAdi, string PersonelSoyadi, string Cinsiyet, decimal Maas, DateTime MaasOdemeTarih, bool MedeniHali, string CalistigiFirma, string Hakkinda, string yasadigiSehir, int personelBilgiId, int kullaniciId);
        Task<string> EmployeeUpdate(int PersonellerId, string PersonelAdi, string PersonelSoyadi, string Cinsiyet, decimal Maas, DateTime MaasOdemeTarih, bool MedeniHali, string CalistigiFirma, string Hakkinda, string yasadigiSehir, bool aktifMi, DateTime EklenmeTarihi, int personelBilgiId, int kullaniciId);
        Task<List<Employees>> EmployeesList();
        Task<List<Employees>> EmployeesList(bool aktifMi);
        Task<string> EmployeeRemove(int PersonellerId);
        Task<string> EmployeeAddRange(IEnumerable<Employees> personeller);
        Task<string> EmployeeRemoveRange(IEnumerable<Employees> personeller);

    }
}
