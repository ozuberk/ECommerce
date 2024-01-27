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
    public class CustomersRepository : GenericRepository<Customers>, ICustomersRepository
    {
        public CustomersRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<string> CustomersAddAsync(string adi, string soyadi, string cinsiyet, string telefon, string meslek, DateTime dogumTarihi, bool aktifMi, DateTime eklenmeTarihi, DateTime guncellenmeTarihi, int kullaniciId)
        {
            try
            {
                Customers musteri = new Customers();
                musteri.CustomerName = adi;
                musteri.CustomerLastName = soyadi;
                musteri.Gender = cinsiyet;
                musteri.PhoneNumber = telefon;
                musteri.Profession = meslek;
                musteri.DateOfBirth = dogumTarihi;
                musteri.Active = aktifMi;
                musteri.AddedDate = eklenmeTarihi;
                musteri.UpdatedDate = guncellenmeTarihi;
                musteri.UserId = kullaniciId;

                await AddAsync(musteri);

                return "Ekleme başarılı";
            }
            catch (Exception)
            {
                return "Ekleme esnasında hata oluştu";
            };
        }

        public async Task<List<Customers>> CustomersListAsync()
        {
            return await _appDbContext.Customers.ToListAsync();
        }

        public async Task<List<Customers>> CustomersListAsync(bool aktifMi)
        {
            return await GetAllQuery(m => m.Active == aktifMi).ToListAsync();
        }

        public async Task<string> CustomersRemoveAsync(int musteriId)
        {
            var musteriSil = await GetByIdAsync(musteriId);

            try
            {
                musteriSil.Active = false;

                return "Silme başarılı";
            }
            catch (Exception)
            {
                return "Silme esnasında hata oluştu";
            }
        }

        public async Task<string> CustomersUpdateAsync(int musteriId, string adi, string soyadi, string cinsiyet, string telefon, string meslek, DateTime dogumTarihi, bool aktifMi, DateTime eklenmeTarihi, DateTime guncellenmeTarihi, int kullaniciId)
        {
            var musteriBul = await GetByIdAsync(musteriId);

            try
            {
                musteriBul.CustomerName = adi;
                musteriBul.CustomerLastName = soyadi;
                musteriBul.Gender = cinsiyet;
                musteriBul.PhoneNumber = telefon;
                musteriBul.Profession = meslek;
                musteriBul.DateOfBirth = dogumTarihi;
                musteriBul.Active = aktifMi;
                musteriBul.AddedDate = eklenmeTarihi;
                musteriBul.UpdatedDate = guncellenmeTarihi;
                musteriBul.UserId = kullaniciId;

                return "Güncelleme başarılı";
            }
            catch (Exception)
            {
                return "Güncelleme esnasında hata oluştu";
            }
        }

        public async Task<List<Customers>> GetCustomersWithAddressAsync()
        {
            return await _appDbContext.Customers.Include(m => m.Addresses).ToListAsync();
        }

        public async Task<Customers> GetCustomersWithAddressAsync(int musteriID)
        {
            return await GetAllQuery(m => m.ID == musteriID).Include(m => m.Addresses).FirstOrDefaultAsync();
        }

        public async Task<List<Customers>> GetCustomersWithOrdersAsync()
        {
            return await _appDbContext.Customers.Include(m => m.Orders).ToListAsync();
        }

        public async Task<Customers> GetCustomersWithOrdersAsync(int musteriID)
        {
            return await GetAllQuery(m => m.ID == musteriID).Include(m => m.Orders).FirstOrDefaultAsync();
        }

        public async Task<List<Customers>> GetCustomersWithUsersAsync()
        {
            return await _appDbContext.Customers.Include(m => m.Users).ToListAsync();
        }

        public async Task<Customers> GetCustomersWithUsersAsync(int musteriID)
        {
            return await GetAllQuery(m => m.ID == musteriID).Include(m => m.Users).FirstOrDefaultAsync();
        }
    }
}
