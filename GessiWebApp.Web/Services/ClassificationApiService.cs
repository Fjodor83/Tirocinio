// GessiWebApp.Web/Services/ClassificationApiService.cs
using GessiWebApp.API.DTOs;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace GessiWebApp.Web.Services
{
    public class ClassificationApiService : IClassificationApiService
    {
        private readonly HttpClient _httpClient;

        public ClassificationApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        public async Task<IEnumerable<ClassificationDto>> GetAllClassificationsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ClassificationDto>>("api/classifications");
        }

        public async Task<ClassificationDto> GetClassificationByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ClassificationDto>($"api/classifications/{id}");
        }

        public async Task<ClassificationDto> CreateClassificationAsync(ClassificationCreateDto classification)
        {
            var response = await _httpClient.PostAsJsonAsync("api/classifications", classification);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ClassificationDto>();
        }

        public async Task<ClassificationDto> UpdateClassificationAsync(int id, ClassificationUpdateDto classification)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/classifications/{id}", classification);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ClassificationDto>();
        }

        public async Task DeleteClassificationAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/classifications/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}