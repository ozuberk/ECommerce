using ECommerce.Core.ECommerceDatabase;
using ECommerce.Web_API.Areas.Areas.APIService;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web_API.Areas.Areas.Controllers
{
    public class _OrderDetailsController : Controller
    {
        private readonly OrderDetailsAPIService _orderDetailsAPIService;

        public _OrderDetailsController(OrderDetailsAPIService orderDetailsAPIService)
        {
            _orderDetailsAPIService = orderDetailsAPIService;
        }

        public async Task<IActionResult> _SiparisDetaylarIndex()
        {
            var detayList = await _orderDetailsAPIService.SiparisDetaylarListAsync();
            return View(detayList);
        }

        [HttpGet]
        public IActionResult _SiparisDetayKaydetIndex()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> _SiparisDetayKaydetIndex(OrderDetails orderDetail)
        {
            var sonuc = await _orderDetailsAPIService.SiparisDetayKaydetAsync(orderDetail);

            if (sonuc != null)
            {
                return RedirectToAction("_SiparisDetaylarIndex");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> _SiparisDetayGuncelleIndex(int id)
        {
            var siparis = await _orderDetailsAPIService.SiparisDetayGetByIdAsync(id);

            return View(siparis);
        }

        [HttpPost]
        public async Task<IActionResult> _SiparisDetayGuncelleIndex(OrderDetails orderDetail)
        {
            try
            {
                await _orderDetailsAPIService.SiparisDetayGuncelleAsync(orderDetail);
                TempData["guncellemeMesaj"] = "<b>Güncelleme başarılı</b>";
                return RedirectToAction("_SiparisDetaylarIndex");
            }
            catch (Exception)
            {
                TempData["hataMesaji"] = "<b>Güncelleme hata verdi, lütfen kontrol ediniz </b>";

                return RedirectToAction("_SiparisDetayGuncelle", orderDetail.OrderDetailId);
            }
        }

        [HttpGet]
        public async Task<IActionResult> _SiparisDetaySilIndex(int Id)
        {
            var siparis = await _orderDetailsAPIService.SiparisDetayGetByIdAsync(Id);
            return View(siparis);
        }


        [HttpPost, ActionName("_SiparisDetaySilIndex")]
        public async Task<IActionResult> _SiparisDetayDeleteIndex(int Id)
        {
            if (ModelState.IsValid)
            {
                await _orderDetailsAPIService.SiparisDetaySilAsync(Id);
                TempData["guncellemeMesaj"] = "<b>Silme başarılı</b>";
                return RedirectToAction("_SiparisDetaylarIndex");
            }

            TempData["hataMesaji"] = "<b>Silme hata verdi, lütfen kontrol ediniz </b>";

            return RedirectToAction("_SiparisDetaySilIndex", Id);
        }
    }
}
