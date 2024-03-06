using ECommerce.Core.ECommerceDatabase;

namespace ECommerce.Web_API.Areas.Areas.APIService
{
    public class AuthorizationsAPIService
    {
        private readonly HttpClient _httpClient;

        public AuthorizationsAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Authorizations>> YetkilerListAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Authorizations>>("Authorizations");

            return response;
        }


        public async Task<Authorizations> YetkiGetByIdAsync(int id)
        {
            string url = $"Yetkiler/YetkiGetById/{id}";
            var response = await _httpClient.GetFromJsonAsync<Authorizations>(url);

            return response;
        }

        public async Task<Authorizations> YetkiKaydetAsync(Authorizations authorization)
        {
            var response = await _httpClient.PostAsJsonAsync("Authorizations", authorization);

            if (response.IsSuccessStatusCode == false)
            {
                return null;
            }
            var responseBody = await response.Content.ReadFromJsonAsync<Authorizations>();

            return responseBody;
        }

        public async Task<Authorizations> YetkiGuncelleAsync(Authorizations authorization)
        {
            var response = await _httpClient.PutAsJsonAsync("Authorizations/AuthorizationUpdate", authorization);

            if (response.IsSuccessStatusCode == false)
            {
                return null;
            }
            var responseBody = await response.Content.ReadFromJsonAsync<Authorizations>();

            return responseBody;
        }

        public async Task<bool> YetkiSilAsync(int id)
        {
            string url = $"Authorizations/AuthorizationDelete/{id}";

            var response = await _httpClient.DeleteAsync(url);

            return response.IsSuccessStatusCode;
        }
    }
}
