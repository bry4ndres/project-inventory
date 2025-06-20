using System.Net.Http.Json;
using TransactionService.Application.DTOs;
using TransactionService.Application.Interfaces;

namespace TransactionService.Infrastructure.Services
{
    public class ProductServiceClient : IProductServiceClient
    {
        private readonly HttpClient _httpClient;

        public ProductServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetStockAsync(int productId)
        {
            var response = await _httpClient.GetAsync($"/api/products/{productId}");
            response.EnsureSuccessStatusCode();
            var product = await response.Content.ReadFromJsonAsync<ProductDto>();

            return product?.Stock ?? 0;
        }

        public async Task UpdateStockAsync(int productId, int quantity)
        {
            var payload = new { Stock = quantity };
            var response = await _httpClient.PutAsJsonAsync($"/api/products/{productId}/stock", payload);
            response.EnsureSuccessStatusCode();
        }
    }
}
