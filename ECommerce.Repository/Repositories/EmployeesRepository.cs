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
    public class EmployeesRepository : GenericRepository<Employees>, IEmployeesRepository
    {
        public EmployeesRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<string> EmployeeAdd(string PersonelAdi, string PersonelSoyadi, string Cinsiyet, decimal Maas, DateTime MaasOdemeTarih, bool MedeniHali, string CalistigiFirma, string Hakkinda, string yasadigiSehir, int personelBilgiId, int kullaniciId)
        {
            try
            {
                Employees personelEkle = new Employees();
                personelEkle.EmployeeName = PersonelAdi;
                personelEkle.EmployeeLastName = PersonelSoyadi;
                personelEkle.Gender = Cinsiyet;
                personelEkle.EmployeeSalary = Maas;
                personelEkle.SalaryPayDate = MaasOdemeTarih;
                personelEkle.MaritalStatus = MedeniHali;
                personelEkle.CompanyName = CalistigiFirma;
                personelEkle.AboutTheEmployee = Hakkinda;
                personelEkle.LivesInACity = yasadigiSehir;
                personelEkle.EmployeeUserInfoId = personelBilgiId;
                personelEkle.UserId = kullaniciId;
                await AddAsync(personelEkle);

                return "Personel ekleme işlemi başarılı";
            }
            catch (Exception)
            {

                return "Personel ekleme işlemi esnasında hata oluştu";
            }
        }

        public async Task<string> EmployeeAddRange(IEnumerable<Employees> personeller)
        {
            try
            {
                await AddRangeAsync(personeller);
                return "Toplu ekleme işlmei başarılı";
            }
            catch (Exception)
            {

                return "Toplu ekleme esnasında hata oluştu";
            }
        }

        public async Task<string> EmployeeRemove(int PersonellerId)
        {
            var personelSil = await GetByIdAsync(PersonellerId);
            try
            {
                if (personelSil != null)
                {
                    Remove(personelSil);
                    await _appDbContext.SaveChangesAsync();
                    return "Silme işlemi başarılı";
                }
                else
                {
                    return "Böyle bir personel bulunamadı";
                }

            }
            catch (Exception)
            {

                return "Silme işlemi esnasında hata oluştu";
            }
        }

        public async Task<string> EmployeeRemoveRange(IEnumerable<Employees> personeller)
        {
            try
            {
                RemoveRange(personeller);
                return "Toplu silme işlemi başarılı";
            }
            catch (Exception)
            {

                return "Toplu silme işlemi esnasında hata oluştu";
            }
        }

        public async Task<List<Employees>> EmployeesList()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<List<Employees>> EmployeesList(bool aktifMi)
        {
            return await GetAllQuery(p => p.Active == aktifMi).ToListAsync();
        }

        public async Task<string> EmployeeUpdate(int PersonellerId, string PersonelAdi, string PersonelSoyadi, string Cinsiyet, decimal Maas, DateTime MaasOdemeTarih, bool MedeniHali, string CalistigiFirma, string Hakkinda, string yasadigiSehir, bool aktifMi, DateTime EklenmeTarihi, int personelBilgiId, int kullaniciId)
        {
            var personelGuncelle = await GetByIdAsync(PersonellerId);
            try
            {

                personelGuncelle.EmployeeName = PersonelAdi;
                personelGuncelle.EmployeeLastName = PersonelSoyadi;
                personelGuncelle.Gender = Cinsiyet;
                personelGuncelle.EmployeeSalary = Maas;
                personelGuncelle.SalaryPayDate = MaasOdemeTarih;
                personelGuncelle.UpdatedDate = DateTime.Now;
                personelGuncelle.MaritalStatus = MedeniHali;
                personelGuncelle.CompanyName = CalistigiFirma;
                personelGuncelle.AboutTheEmployee = Hakkinda;
                personelGuncelle.LivesInACity = yasadigiSehir;
                personelGuncelle.Active = aktifMi;
                personelGuncelle.AddedDate = EklenmeTarihi;
                personelGuncelle.EmployeeUserInfoId = personelBilgiId;
                personelGuncelle.UserId = kullaniciId;

                return "Personel güncelleme işlemi başarılı";
            }
            catch (Exception)
            {

                return "Personel güncelleme işlemi esnasında hata oluştu";
            }
        }

        public async Task<List<Employees>> GetEmployeesWithUsersAsync()
        {
            return await _appDbContext.Employees.Include(k => k.Users).ToListAsync();
        }

        public async Task<Employees> GetEmployeesWithUsersAsync(int personellerId)
        {
            return await _appDbContext.Employees.Where(k => k.ID == personellerId).Include(k => k.Users).FirstOrDefaultAsync();
        }
    }
}
