// GessiWebApp.Web/Services/WarehouseApiService.cs
using GessiWebApp.API.DTOs;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace GessiWebApp.Web.Services
{
    public class WarehouseApiService : IWarehouseApiService
    {
        private readonly HttpClient _httpClient;

        public WarehouseApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        public async Task<IEnumerable<WarehouseDto>> GetAllWarehousesAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<WarehouseDto>>("api/warehouses");
        }

        public async Task<WarehouseDto> GetWarehouseByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<WarehouseDto>($"api/warehouses/{id}");
        }

        public async Task<WarehouseDto> CreateWarehouseAsync(WarehouseDto warehouse)
        {
            var response = await _httpClient.PostAsJsonAsync("api/warehouses", warehouse);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<WarehouseDto>();
        }

        public async Task<WarehouseDto> UpdateWarehouseAsync(int id, WarehouseDto warehouse)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/warehouses/{id}", warehouse);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<WarehouseDto>();
        }

        public async Task DeleteWarehouseAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/warehouses/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}