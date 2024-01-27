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
    public class UsersRepository : GenericRepository<Users>, IUsersRepository
    {
        public UsersRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Users> GetUsers(int kullaniciId)
        {
            var getir = Find(k => k.ID == kullaniciId);
            var sonuc = getir.FirstOrDefault();
            return sonuc;
        }

        public async Task<List<Users>> GetUsersWithAuthorizationsAsync()
        {
            return await _appDbContext.Users.Include(k => k.Authorizations).ToListAsync();
        }

        public async Task<Users> GetUsersWithAuthorizationsAsync(int kullanicilarId)
        {
            return await _appDbContext.Users.Where(k => k.ID == kullanicilarId).Include(k => k.Authorizations).FirstOrDefaultAsync();
        }

        public async Task<Users> Login(string kullaniciAdi, string sifre)
        {
            var kullaniciList = Find(k => k.UserName == kullaniciAdi && k.UserPassword == sifre);
            var kullanici = kullaniciList.FirstOrDefault();

            return kullanici;
        }

        public async Task<string> UsersAdd(string Adi, string Soyadi, string Resim, string KullaniciEmail, string KullaniciSifre, bool PersonelMi, int YetkiId)
        {
            try
            {
                Users kullaniciEkle = new Users();
                kullaniciEkle.UserName = Adi;
                kullaniciEkle.UserLastName = Soyadi;
                kullaniciEkle.UserPicture = Resim;
                kullaniciEkle.UserEmail = KullaniciEmail;
                kullaniciEkle.UserPassword = KullaniciSifre;
                kullaniciEkle.AnEmployee = PersonelMi;
                kullaniciEkle.AuthorityId = YetkiId;
                await AddAsync(kullaniciEkle);

                return "Ekleme Başarılı";
            }
            catch (Exception)
            {

                return "Ekleme işlemi esnasında hata oluştu";
            }

        }

        public async Task<string> UsersAddRange(IEnumerable<Users> kullanicilar)
        {
            try
            {
                await AddRangeAsync(kullanicilar);
                return "Toplu ekleme başarılı";
            }
            catch (Exception)
            {

                return "Toplu ekleme işlemi esnasında hata oluştu";
            }
        }

        public async Task<List<Users>> UsersList()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<List<Users>> UsersList(bool aktifMi)
        {
            return await GetAllQuery(k => k.Active == aktifMi).ToListAsync();
        }

        public async Task<string> UsersRemove(int KullanicilarId)
        {
            var kullaniciSil = await GetByIdAsync(KullanicilarId);

            try
            {
                if (kullaniciSil != null)
                {
                    Remove(kullaniciSil);
                    await _appDbContext.SaveChangesAsync();
                    return "Silme işlemi başarılı";

                }
                else
                {
                    return "Kullanıcı bulunamadı";
                }
            }
            catch (Exception)
            {

                return "Silme işlemi esnasında hata oluştu";
            }
        }

        public async Task<string> UsersRemoveRange(IEnumerable<Users> kullanicilar)
        {
            try
            {
                RemoveRange(kullanicilar);
                return "Toplu silme işlemi başarılı";
            }
            catch (Exception)
            {

                return "Toplu silme işlemi esnasında hata oluştu";
            }
        }

        public async Task<string> UsersUpdate(int KullanicilarId, string Adi, string Soyadi, string Resim, string KullaniciEmail, string KullaniciSifre, bool PersonelMi, bool aktifMi, DateTime EklenmeTarihi, int YetkiId)
        {
            var kullaniciGuncelle = await GetByIdAsync(KullanicilarId);
            try
            {
                kullaniciGuncelle.UserName = Adi;
                kullaniciGuncelle.UserLastName = Soyadi;
                kullaniciGuncelle.UserPicture = Resim;
                kullaniciGuncelle.UserEmail = KullaniciEmail;
                kullaniciGuncelle.UserPassword = KullaniciSifre;
                kullaniciGuncelle.AnEmployee = PersonelMi;
                kullaniciGuncelle.Active = aktifMi;
                kullaniciGuncelle.AddedDate = EklenmeTarihi;
                kullaniciGuncelle.UpdatedDate = DateTime.Now;
                kullaniciGuncelle.AuthorityId = YetkiId;
                return "Güncelleme işlemi başarılı";

            }
            catch (Exception)
            {

                return "Güncelleme işlemi esnasında hata oluştu";
            }
        }
    }
}
