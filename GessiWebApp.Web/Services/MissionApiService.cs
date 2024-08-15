// GessiWebApp.Web/Services/MissionApiService.cs
using GessiWebApp.API.DTOs;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace GessiWebApp.Web.Services
{
    public class MissionApiService : IMissionApiService
    {
        private readonly HttpClient _httpClient;

        public MissionApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        public async Task<IEnumerable<MissionDto>> GetAllMissionsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<MissionDto>>("api/missions");
        }

        public async Task<MissionDto> GetMissionByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<MissionDto>($"api/missions/{id}");
        }

        public async Task<MissionDto> CreateMissionAsync(MissionCreateDto mission)
        {
            var response = await _httpClient.PostAsJsonAsync("api/missions", mission);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<MissionDto>();
        }

        public async Task<MissionDto> UpdateMissionAsync(int id, MissionUpdateDto mission)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/missions/{id}", mission);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<MissionDto>();
        }

        public async Task<MissionDto> CompleteMissionAsync(int id)
        {
            var response = await _httpClient.PostAsync($"api/missions/{id}/complete", null);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<MissionDto>();
        }

        public async Task DeleteMissionAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/missions/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}