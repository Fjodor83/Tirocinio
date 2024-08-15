// GessiWebApp.Web/Services/MovementApiService.cs
using GessiWebApp.API.DTOs;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace GessiWebApp.Web.Services
{
    public class MovementApiService : IMovementApiService
    {
        private readonly HttpClient _httpClient;

        public MovementApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        public async Task<IEnumerable<MovementDto>> GetAllMovementsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<MovementDto>>("api/movements");
        }

        public async Task<MovementDto> GetMovementByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<MovementDto>($"api/movements/{id}");
        }

        public async Task<MovementDto> CreateIncomingMovementAsync(MovementCreateDto movement)
        {
            var response = await _httpClient.PostAsJsonAsync("api/movements/incoming", movement);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<MovementDto>();
        }

        public async Task<MovementDto> CreateOutgoingMovementAsync(MovementCreateDto movement)
        {
            var response = await _httpClient.PostAsJsonAsync("api/movements/outgoing", movement);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<MovementDto>();
        }
    }
}