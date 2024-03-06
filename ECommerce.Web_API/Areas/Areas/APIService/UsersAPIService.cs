using ECommerce.Core.ECommerceDatabase;

namespace ECommerce.Web_API.Areas.Areas.APIService
{
    public class UsersAPIService
    {
        private readonly HttpClient _httpClient;

        public UsersAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Users>> KullanicilarList()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Users>>("Users");

            return response;
        }




        public async Task<Users> KullaniciGetByIdAsync(int id)
        {
            string url = $"Users/UserGetById/{id}";
            var response = await _httpClient.GetFromJsonAsync<Users>(url);

            return response;
        }

        public async Task<Users> KullaniciKaydetAsync(Users user)
        {
            var response = await _httpClient.PostAsJsonAsync("Users", user);

            if (response.IsSuccessStatusCode == false)
            {
                return null;
            }
            var responseBody = await response.Content.ReadFromJsonAsync<Users>();

            return responseBody;
        }

        public async Task<Users> KullaniciGuncelleAsync(Users user)
        {
            var response = await _httpClient.PutAsJsonAsync("Users/UserUpdate", user);

            if (response.IsSuccessStatusCode == false)
            {
                return null;
            }
            var responseBody = await response.Content.ReadFromJsonAsync<Users>();

            return responseBody;
        }

        public async Task<bool> KullaniciSilAsync(int id)
        {
            string url = $"Users/UserDelete/{id}";
            var response = await _httpClient.DeleteAsync(url);

            return response.IsSuccessStatusCode;
        }
    }
}
