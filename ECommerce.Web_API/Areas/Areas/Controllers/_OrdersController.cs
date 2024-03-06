using ECommerce.Core.ECommerceDatabase;
using ECommerce.Web_API.Areas.Areas.APIService;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web_API.Areas.Areas.Controllers
{
    public class _OrdersController : Controller
    {
        private readonly OrdersAPIService _ordersAPIService;

        public _OrdersController(OrdersAPIService ordersAPIService)
        {
            _ordersAPIService = ordersAPIService;
        }

        public async Task<IActionResult> _SiparislerIndex()
        {
            var siparisList = await _ordersAPIService.SiparislerListAsync();
            return View(siparisList);
        }

        [HttpGet]
        public IActionResult _SiparisKaydetIndex()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> _SiparisKaydetIndex(Orders order)
        {
            order.AddedDate = DateTime.Now;
            order.Active = true;
            order.CustomerId = 1;
            var sonuc = await _ordersAPIService.SiparisKaydetAsync(order);

            if (sonuc != null)
            {
                return RedirectToAction("_SiparislerIndex");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> _SiparisGuncelleIndex(int id)
        {
            var siparis = await _ordersAPIService.SiparisGetByIdAsync(id);

            return View(siparis);
        }

        [HttpPost]
        public async Task<IActionResult> _SiparisGuncelleIndex(Orders order)
        {
            try
            {
                order.Active = true;
                order.UpdatedDate = DateTime.Now;
                order.CustomerId = 1;
                await _ordersAPIService.SiparisGuncelleAsync(order);
                TempData["guncellemeMesaj"] = "<b>Güncelleme başarılı</b>";
                return RedirectToAction("_SiparislerIndex");
            }
            catch (Exception)
            {
                TempData["hataMesaji"] = "<b>Güncelleme hata verdi, lütfen kontrol ediniz </b>";

                return RedirectToAction("_SiparisGuncelle", order.ID);
            }
        }

        [HttpGet]
        public async Task<IActionResult> _SiparisSilIndex(int Id)
        {
            var siparis = await _ordersAPIService.SiparisGetByIdAsync(Id);
            return View(siparis);
        }


        [HttpPost, ActionName("_SiparisSilIndex")]
        public async Task<IActionResult> _SiparisDeleteIndex(int Id)
        {
            if (ModelState.IsValid)
            {
                await _ordersAPIService.SiparisSilAsync(Id);
                TempData["guncellemeMesaj"] = "<b>Silme başarılı</b>";
                return RedirectToAction("_SiparislerIndex");
            }

            TempData["hataMesaji"] = "<b>Silme hata verdi, lütfen kontrol ediniz </b>";

            return RedirectToAction("_SiparisSilIndex", Id);
        }
    }
}
