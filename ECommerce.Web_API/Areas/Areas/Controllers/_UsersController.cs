using ECommerce.Core.ECommerceDatabase;
using ECommerce.Web_API.Areas.Areas.APIService;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web_API.Areas.Areas.Controllers
{
    public class _UsersController : Controller
    {
        private readonly UsersAPIService _usersAPIService;
        private readonly AuthorizationsAPIService _authorizationsAPIService;

        public _UsersController(UsersAPIService usersAPIService, AuthorizationsAPIService authorizationsAPIService)
        {
            _usersAPIService = usersAPIService;
            _authorizationsAPIService = authorizationsAPIService;
        }

        public async Task<IActionResult> _KullanicilarIndex()
        {
            var KullaniciList = await _usersAPIService.KullanicilarList();
            return View(KullaniciList);
        }

        [HttpGet]
        public async Task<IActionResult> _KullaniciGuncelleIndex(int id)
        {
            var kullanici = await _usersAPIService.KullaniciGetByIdAsync(id);
            ViewBag.yetkiler = await _authorizationsAPIService.YetkilerListAsync();
            return View(kullanici);
        }

        [HttpPost]
        public async Task<IActionResult> _KullaniciGuncelleIndex(Users user)
        {
            try
            {
                user.Active = true;
                user.UpdatedDate = DateTime.Now;
                await _usersAPIService.KullaniciGuncelleAsync(user);
                TempData["guncellemeMesaj"] = "<b>Güncelleme başarılı</b>";
                return RedirectToAction("_KullanicilarIndex");
            }
            catch (Exception)
            {
                TempData["hataMesaji"] = "<b>Güncelleme hata verdi, lütfen kontrol ediniz </b>";

                return RedirectToAction("_KullaniciGuncelle", user.ID);
            }
        }

        [HttpGet]
        public async Task<IActionResult> _KullaniciSilIndex(int Id)
        {
            var kullanici = await _usersAPIService.KullaniciGetByIdAsync(Id);
            return View(kullanici);
        }


        [HttpPost, ActionName("_KullaniciSilIndex")]
        public async Task<IActionResult> _KullaniciDeleteIndex(int Id)
        {
            if (ModelState.IsValid)
            {
                await _usersAPIService.KullaniciSilAsync(Id);
                TempData["guncellemeMesaj"] = "<b>Silme başarılı</b>";
                return RedirectToAction("_KullanicilarIndex");
            }

            TempData["hataMesaji"] = "<b>Silme hata verdi, lütfen kontrol ediniz </b>";

            return RedirectToAction("_KullaniciSilIndex", Id);
        }
    }
}
