using ECommerce.Core.ECommerceDatabase;
using ECommerce.Web_API.Areas.Areas.APIService;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web_API.Areas.Areas.Controllers
{
    public class _ProductsController : Controller
    {
        private readonly ProductsAPIService _productsAPIService;
        private readonly CategoriesAPIService _categoriesAPIService;
        public _ProductsController(ProductsAPIService productsAPIService, CategoriesAPIService categoriesAPIService)
        {
            _productsAPIService = productsAPIService;
            _categoriesAPIService = categoriesAPIService;

        }

        public async Task<IActionResult> _UrunlerIndex()
        {
            var urunList = await _productsAPIService.ProductsList();
            return View(urunList);
        }

        [HttpGet]
        public async Task<IActionResult> _UrunKaydetIndex()
        {
            ViewBag.kategoriler = await _categoriesAPIService.KategorilerListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> _UrunKaydetIndex(Products product)
        {
            product.AddedDate = DateTime.Now;
            product.Active = true;
            var sonuc = await _productsAPIService.UrunKaydetAsync(product);

            if (sonuc != null)
            {
                return RedirectToAction("_UrunlerIndex");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> _UrunGuncelleIndex(int id)
        {
            var urun = await _productsAPIService.UrunGetByIdAsync(id);
            var kategoriler = await _categoriesAPIService.KategorilerListAsync();

            var model = new Tuple<List<Categories>, Products>(kategoriler, urun);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> _UrunGuncelleIndex(Products product)
        {
            try
            {
                product.Active = true;
                product.UpdatedDate = DateTime.Now;
                await _productsAPIService.UrunGuncelleAsync(product);
                TempData["guncellemeMesaj"] = "<b>Güncelleme başarılı</b>";
                return RedirectToAction("_UrunlerIndex");
            }
            catch (Exception)
            {
                TempData["hataMesaji"] = "<b>Güncelleme hata verdi, lütfen kontrol ediniz </b>";

                return RedirectToAction("_UrunGuncelle", product.ID);
            }
        }

        [HttpGet]
        public async Task<IActionResult> _UrunSilIndex(int Id)
        {
            var urun = await _productsAPIService.UrunGetByIdAsync(Id);
            return View(urun);
        }


        [HttpPost, ActionName("_UrunSilIndex")]
        public async Task<IActionResult> _UrunDeleteIndex(int Id)
        {
            if (ModelState.IsValid)
            {
                await _productsAPIService.UrunSilAsync(Id);
                TempData["guncellemeMesaj"] = "<b>Silme başarılı</b>";
                return RedirectToAction("_UrunlerIndex");
            }

            TempData["hataMesaji"] = "<b>Silme hata verdi, lütfen kontrol ediniz </b>";

            return RedirectToAction("_UrunSilIndex", Id);
        }
    }
}
