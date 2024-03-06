using ECommerce.Core.ECommerceDatabase;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web_API.Areas.Areas.APIService
{
    public class ProductsAPIService
    {
        private readonly HttpClient _httpClient;
        public ProductsAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Products>> ProductsList()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Products>>("Products/Products");

            return response;
        }


        public async Task<Products> UrunKaydetAsync(Products product)
        {
            var response = await _httpClient.PostAsJsonAsync("Products", product);

            if (response.IsSuccessStatusCode == false)
            {
                return null;
            }
            var responseBody = await response.Content.ReadFromJsonAsync<Products>();

            return responseBody;
        }

        public async Task<Products> UrunGuncelleAsync(Products product)
        {
            var response = await _httpClient.PutAsJsonAsync("Products/ProductUpdate", product);

            if (response.IsSuccessStatusCode == false)
            {
                return null;
            }
            var responseBody = await response.Content.ReadFromJsonAsync<Products>();

            return responseBody;
        }

        public async Task<bool> UrunSilAsync(int id)
        {
            string url = $"Products/ProductDelete/{id}";
            var response = await _httpClient.DeleteAsync(url);

            return response.IsSuccessStatusCode; ;
        }

        public async Task<Products> UrunGetByIdAsync(int id)
        {
            string url = $"Products/ProductGetById/{id}";
            var response = await _httpClient.GetFromJsonAsync<Products>(url);

            return response;
        }
    }
}
