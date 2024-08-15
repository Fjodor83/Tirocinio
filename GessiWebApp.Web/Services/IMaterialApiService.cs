// GessiWebApp.Web/Services/IMaterialApiService.cs
using GessiWebApp.API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GessiWebApp.Web.Services
{
    public interface IMaterialApiService
    {
        Task<IEnumerable<MaterialDto>> GetAllMaterialsAsync();
        Task<MaterialDto> GetMaterialByIdAsync(int id);
        Task<MaterialDto> CreateMaterialAsync(MaterialCreateDto material);
        Task<MaterialDto> UpdateMaterialAsync(int id, MaterialUpdateDto material);
        Task DeleteMaterialAsync(int id);
        Task<IEnumerable<MaterialDto>> GetAllMaterialsWithInventoryAsync();
    }
}