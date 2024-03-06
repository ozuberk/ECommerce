using ECommerce.Core.ECommerceDatabase;

namespace ECommerce.Web_API.Areas.Areas.APIService
{
    public class OrdersAPIService
    {
        private readonly HttpClient _httpClient;
        public OrdersAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Orders>> SiparislerListAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Orders>>("Orders");

            return response;
        }

        public async Task<List<Orders>> SiparislerUpdateDTOListAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Orders>>("Orders/OrderList");

            return response;
        }

        public async Task<Orders> SiparisGetByIdAsync(int id)
        {
            string url = $"Orders/OrderGetById/{id}";
            var response = await _httpClient.GetFromJsonAsync<Orders>(url);

            return response;
        }

        public async Task<Orders> SiparisKaydetAsync(Orders order)
        {
            var response = await _httpClient.PostAsJsonAsync("Orders", order);

            if (response.IsSuccessStatusCode == false)
            {
                return null;
            }
            var responseBody = await response.Content.ReadFromJsonAsync<Orders>();

            return responseBody;
        }

        public async Task<Orders> SiparisGuncelleAsync(Orders order)
        {
            var response = await _httpClient.PutAsJsonAsync("Orders/OrderUpdate", order);

            if (response.IsSuccessStatusCode == false)
            {
                return null;
            }
            var responseBody = await response.Content.ReadFromJsonAsync<Orders>();

            return responseBody;
        }

        public async Task<bool> SiparisSilAsync(int id)
        {
            string url = $"Orders/OrderDelete/{id}";
            var response = await _httpClient.DeleteAsync(url);

            return response.IsSuccessStatusCode;
        }
    }
}
