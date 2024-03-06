using ECommerce.Core.ECommerceDatabase;
using ECommerce.Web_API.Areas.Areas.APIService;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web_API.Areas.Areas.Controllers
{
    public class _MenusController : Controller
    {
        private readonly MenusAPIService _menusAPIService;

        public _MenusController(MenusAPIService menusAPIService)
        {
            _menusAPIService = menusAPIService;
        }

        public async Task<IActionResult> _MenulerIndex()
        {
            var menuList = await _menusAPIService.MenulerListAsync();
            return View(menuList);
        }

        [HttpGet]
        public async Task<IActionResult> _MenuKaydetIndex()
        {

            var menuler = await _menusAPIService.MenulerListAsync();
            ViewBag.menuler = menuler;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> _MenuKaydetIndex(Menus menu)
        {
            menu.AddedDate = DateTime.Now;
            menu.Active = true;
            var sonuc = await _menusAPIService.MenuKaydetAsync(menu);

            if (sonuc != null)
            {
                return RedirectToAction("_MenulerIndex");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> _MenuGuncelleIndex(int id)
        {

            var menuler = await _menusAPIService.MenulerListAsync();
            ViewBag.menuler = menuler;

            return View(menuler);
        }

        [HttpPost]
        public async Task<IActionResult> _MenuGuncelleIndex(Menus menu)
        {
            try
            {
                menu.Active = true;
                menu.UpdatedDate = DateTime.Now;
                await _menusAPIService.MenuGuncelleAsync(menu);
                TempData["guncellemeMesaj"] = "<b>Güncelleme başarılı</b>";
                return RedirectToAction("_MenulerIndex");
            }
            catch (Exception)
            {
                TempData["hataMesaji"] = "<b>Güncelleme hata verdi, lütfen kontrol ediniz </b>";

                return RedirectToAction("_MenuGuncelle", menu.ID);
            }
        }

        [HttpGet]
        public async Task<IActionResult> _MenuSilIndex(int Id)
        {
            var menu = await _menusAPIService.MenuGetByIdAsync(Id);
            return View(menu);
        }


        [HttpPost, ActionName("_MenuSilIndex")]
        public async Task<IActionResult> _MenuDeleteIndex(int Id)
        {
            if (ModelState.IsValid)
            {
                await _menusAPIService.MenuSilAsync(Id);
                TempData["guncellemeMesaj"] = "<b>Silme başarılı</b>";
                return RedirectToAction("_MenulerIndex");
            }

            TempData["hataMesaji"] = "<b>Silme hata verdi, lütfen kontrol ediniz </b>";

            return RedirectToAction("_MenuSilIndex", Id);
        }
    }
}
