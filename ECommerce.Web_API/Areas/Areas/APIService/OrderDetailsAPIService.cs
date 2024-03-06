using ECommerce.Core.ECommerceDatabase;

namespace ECommerce.Web_API.Areas.Areas.APIService
{
    public class OrderDetailsAPIService
    {
        private readonly HttpClient _httpClient;

        public OrderDetailsAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<OrderDetails>> SiparisDetaylarListAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<OrderDetails>>("OrderDetails");

            return response;
        }

        public async Task<List<OrderDetails>> SiparisDetaylarUpdateDTOListAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<OrderDetails>>("OrderDetails/OrderDetailsList");

            return response;
        }

        public async Task<OrderDetails> SiparisDetayGetByIdAsync(int id)
        {
            string url = $"OrderDetails/OrderDetailGetById/{id}";
            var response = await _httpClient.GetFromJsonAsync<OrderDetails>(url);

            return response;
        }

        public async Task<OrderDetails> SiparisDetayKaydetAsync(OrderDetails orderDetails)
        {
            var response = await _httpClient.PostAsJsonAsync("OrderDetails", orderDetails);

            if (response.IsSuccessStatusCode == false)
            {
                return null;
            }
            var responseBody = await response.Content.ReadFromJsonAsync<OrderDetails>();

            return responseBody;
        }

        public async Task<OrderDetails> SiparisDetayGuncelleAsync(OrderDetails orderDetails)
        {
            var response = await _httpClient.PutAsJsonAsync("OrderDetails/OrderDetailUpdate", orderDetails);

            if (response.IsSuccessStatusCode == false)
            {
                return null;
            }
            var responseBody = await response.Content.ReadFromJsonAsync<OrderDetails>();

            return responseBody;
        }

        public async Task<bool> SiparisDetaySilAsync(int id)
        {
            string url = $"OrderDetails/OrderDetailDelete/{id}";
            var response = await _httpClient.DeleteAsync(url);

            return response.IsSuccessStatusCode;
        }
    }
}
