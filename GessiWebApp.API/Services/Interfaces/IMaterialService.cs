using GessiWebApp.API.DTOs;

namespace GessiWebApp.API.Services.Interfaces
{
    public interface IMaterialService
    {
        Task<IEnumerable<MaterialDto>> GetAllMaterialsAsync();
        Task<MaterialDto> GetMaterialByIdAsync(int id);
        Task<MaterialDto> CreateMaterialAsync(MaterialCreateDto materialDto);
        Task<MaterialDto> UpdateMaterialAsync(int id, MaterialUpdateDto materialDto);
        Task DeleteMaterialAsync(int id);
    }
}