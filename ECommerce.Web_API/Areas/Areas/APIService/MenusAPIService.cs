using ECommerce.Core.ECommerceDatabase;

namespace ECommerce.Web_API.Areas.Areas.APIService
{
    public class MenusAPIService
    {
        private readonly HttpClient _httpClient;
        public MenusAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Menus>> MenulerListAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Menus>>("Menus");

            return response;
        }

        public async Task<Menus> MenuKaydetAsync(Menus menu)
        {
            var response = await _httpClient.PostAsJsonAsync("Menus", menu);

            if (response.IsSuccessStatusCode == false)
            {
                return null;
            }
            var responseBody = await response.Content.ReadFromJsonAsync<Menus>();

            return responseBody;
        }

        public async Task<Menus> MenuGuncelleAsync(Menus menu)
        {
            var response = await _httpClient.PutAsJsonAsync("Menus/MenuUpdate", menu);

            if (response.IsSuccessStatusCode == false)
            {
                return null;
            }
            var responseBody = await response.Content.ReadFromJsonAsync<Menus>();

            return responseBody;
        }

        public async Task<bool> MenuSilAsync(int menuId)
        {
            string url = $"Menus/MenuDelete/{menuId}";
            var response = await _httpClient.DeleteAsync(url);

            return response.IsSuccessStatusCode;
        }
        public async Task<Menus> MenuGetByIdAsync(int menuId)
        {
            string id = menuId.ToString();
            var response = await _httpClient.GetFromJsonAsync<Menus>("Menus/MenuWithGetById/" + id);

            return response;
        }
    }
}
