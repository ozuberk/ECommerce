using ECommerce.Core.ECommerceDatabase;
using ECommerce.Web_API.Areas.Areas.APIService;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web_API.Areas.Areas.Controllers
{
    public class _CategoriesController : Controller
    {
        private readonly CategoriesAPIService _categoriesAPIService;
        public _CategoriesController(CategoriesAPIService categoriesAPIService)
        {
            _categoriesAPIService = categoriesAPIService;
        }
        public async Task<IActionResult> _KategorilerIndex()
        {
            var kategoriList = await _categoriesAPIService.KategorilerListAsync();
            return View(kategoriList);
        }

        [HttpGet]
        public IActionResult _KategoriKaydetIndex()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> _KategoriKaydetIndex(Categories category)
        {
            category.AddedDate = DateTime.Now;
            category.Active = true;
            var sonuc = await _categoriesAPIService.KategoriKaydetAsync(category);

            if (sonuc != null)
            {
                return RedirectToAction("_KategorilerIndex");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> _KategoriGuncelleIndex(int id)
        {
            var kategori = await _categoriesAPIService.KategoriGetByIdAsync(id);

            return View(kategori);
        }

        [HttpPost]
        public async Task<IActionResult> _KategoriGuncelleIndex(Categories category)
        {
            try
            {
                category.Active = true;
                category.UpdatedDate = DateTime.Now;
                await _categoriesAPIService.KategoriGuncelleAsync(category);
                TempData["guncellemeMesaj"] = "<b>Güncelleme başarılı</b>";
                return RedirectToAction("_KategorilerIndex");
            }
            catch (Exception)
            {
                TempData["hataMesaji"] = "<b>Güncelleme hata verdi, lütfen kontrol ediniz </b>";

                return RedirectToAction("_KategoriGuncelle", category.ID);
            }
        }

        [HttpGet]
        public async Task<IActionResult> _KategoriSilIndex(int Id)
        {
            var kategori = await _categoriesAPIService.KategoriGetByIdAsync(Id);
            return View(kategori);
        }


        [HttpPost, ActionName("_KategoriSilIndex")]
        public async Task<IActionResult> _KategoriDeleteIndex(int Id)
        {
            if (ModelState.IsValid)
            {
                await _categoriesAPIService.KategoriSilAsync(Id);
                TempData["guncellemeMesaj"] = "<b>Silme başarılı</b>";
                return RedirectToAction("_KategorilerIndex");
            }

            TempData["hataMesaji"] = "<b>Silme hata verdi, lütfen kontrol ediniz </b>";

            return RedirectToAction("_KategoriSilIndex", Id);
        }
    }
}
