using ECommerce.Core.ECommerceDatabase;
using ECommerce.Core.IService;
using ECommerce.Web_API.Areas.Areas.APIService;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web_API.Areas.Areas.Controllers
{
    public class _AuthorizationsController : Controller
    {
        private readonly AuthorizationsAPIService _authorizationsAPIService;
        private readonly IAuthorizationsService _authorizationsService;
        public _AuthorizationsController(AuthorizationsAPIService authorizationsAPIService, IAuthorizationsService authorizationsService)
        {
            _authorizationsAPIService = authorizationsAPIService;
            _authorizationsService = authorizationsService;
        }

        public async Task<IActionResult> _YetkilerIndex()
        {
            var yetkiList = await _authorizationsAPIService.YetkilerListAsync();
            return View(yetkiList);
        }

        [HttpGet]
        public async Task<IActionResult> _YetkiKaydetIndex()
        {
            var yetkiler = await _authorizationsAPIService.YetkilerListAsync();

            ViewData["yetkiErisim"] = await _authorizationsService.GetAllAsync();

            return View(yetkiler);
        }

        [HttpPost]
        public async Task<IActionResult> _YetkiKaydetIndex(Authorizations authorization)
        {
            var yetkiErisimleri = await _authorizationsService.GetAllAsync();


            var sonuc = await _authorizationsAPIService.YetkiKaydetAsync(authorization);
            if (sonuc != null)
            {
                sonuc.AddedDate = DateTime.Now;
                sonuc.Active = true;
                return RedirectToAction("_YetkilerIndex");
            }


            ViewData["yetkiErisim"] = yetkiErisimleri;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> _YetkiGuncelleIndex(int Id)
        {
            var yetki = await _authorizationsAPIService.YetkiGetByIdAsync(Id);
            return View(yetki);

        }
        [HttpPost]
        public async Task<IActionResult> _YetkiGuncelleIndex(Authorizations authorization)
        {
            try
            {
                await _authorizationsAPIService.YetkiKaydetAsync(authorization);


                return RedirectToAction("_YetkilerIndex");
            }
            catch (Exception)
            {
                return RedirectToAction("_YetkiGuncelleIndex", authorization.ID);
            }
        }

        [HttpGet]
        public async Task<IActionResult> _YetkiSilIndex(int Id)
        {
            var yetki = await _authorizationsAPIService.YetkiGetByIdAsync(Id);
            return View(yetki);
        }


        [HttpPost, ActionName("_YetkiSilIndex")]
        public async Task<IActionResult> _YetkiDeleteIndex(int Id)
        {

            if (ModelState.IsValid)
            {

                await _authorizationsAPIService.YetkiSilAsync(Id);

                TempData["guncellemeMesaj"] = "<b>Silme başarılı</b>";
                return RedirectToAction("_YetkilerIndex");
            }

            TempData["hataMesaji"] = "<b>Silme hata verdi, lütfen kontrol ediniz </b>";

            return RedirectToAction("_YetkiSilIndex", Id);
        }
    }
}
