using GessiWebApp.API.DTOs;

namespace GessiWebApp.API.Services.Interfaces
{
    public interface IMissionService
    {
        Task<IEnumerable<MissionDto>> GetAllMissionsAsync();
        Task<MissionDto> GetMissionByIdAsync(int id);
        Task<MissionDto> CreateMissionAsync(MissionCreateDto missionDto);
        Task<MissionDto> UpdateMissionAsync(int id, MissionUpdateDto missionDto);
        Task DeleteMissionAsync(int id);
    }
}