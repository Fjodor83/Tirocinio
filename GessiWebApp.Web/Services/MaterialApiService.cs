// GessiWebApp.Web/Services/MaterialApiService.cs
using GessiWebApp.API.DTOs;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace GessiWebApp.Web.Services
{
    public class MaterialApiService : IMaterialApiService
    {
        private readonly HttpClient _httpClient;

        public MaterialApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        public async Task<IEnumerable<MaterialDto>> GetAllMaterialsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<MaterialDto>>("api/materials");
        }

        public async Task<MaterialDto> GetMaterialByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<MaterialDto>($"api/materials/{id}");
        }

        public async Task<MaterialDto> CreateMaterialAsync(MaterialCreateDto material)
        {
            var response = await _httpClient.PostAsJsonAsync("api/materials", material);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<MaterialDto>();
        }

        public async Task<MaterialDto> UpdateMaterialAsync(int id, MaterialUpdateDto material)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/materials/{id}", material);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<MaterialDto>();
        }

        public async Task DeleteMaterialAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/materials/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<MaterialDto>> GetAllMaterialsWithInventoryAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<MaterialDto>>("api/materials/inventory");
        }
    }
}