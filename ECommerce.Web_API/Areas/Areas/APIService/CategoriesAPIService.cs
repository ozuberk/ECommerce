using ECommerce.Core.ECommerceDatabase;

namespace ECommerce.Web_API.Areas.Areas.APIService
{
    public class CategoriesAPIService
    {
        private readonly HttpClient _httpClient;
        public CategoriesAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Categories>> KategorilerListAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Categories>>("Categories");

            return response;
        }

        public async Task<Categories> KategoriGetByIdAsync(int id)
        {
            string url = $"Categories/GetCategoryById/{id}";
            var response = await _httpClient.GetFromJsonAsync<Categories>(url);

            return response;
        }

        public async Task<Categories> KategoriKaydetAsync(Categories category)
        {
            var response = await _httpClient.PostAsJsonAsync("Categories", category);

            if (response.IsSuccessStatusCode == false)
            {
                return null;
            }
            var responseBody = await response.Content.ReadFromJsonAsync<Categories>();

            return responseBody;
        }

        public async Task<Categories> KategoriGuncelleAsync(Categories category)
        {
            var response = await _httpClient.PutAsJsonAsync("Categories/CategoryUpdate", category);

            if (response.IsSuccessStatusCode == false)
            {
                return null;
            }
            var responseBody = await response.Content.ReadFromJsonAsync<Categories>();

            return responseBody;
        }

        public async Task<bool> KategoriSilAsync(int Id)
        {
            string url = $"Categories/CategoryDelete/{Id}";
            var response = await _httpClient.DeleteAsync(url);

            return response.IsSuccessStatusCode;
        }
    }
}
