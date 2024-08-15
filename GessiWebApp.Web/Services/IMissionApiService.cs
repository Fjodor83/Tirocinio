// GessiWebApp.Web/Services/IMissionApiService.cs
using GessiWebApp.API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GessiWebApp.Web.Services
{
    public interface IMissionApiService
    {
        Task<IEnumerable<MissionDto>> GetAllMissionsAsync();
        Task<MissionDto> GetMissionByIdAsync(int id);
        Task<MissionDto> CreateMissionAsync(MissionCreateDto mission);
        Task<MissionDto> UpdateMissionAsync(int id, MissionUpdateDto mission);
        Task<MissionDto> CompleteMissionAsync(int id);
        Task DeleteMissionAsync(int id);
    }
}