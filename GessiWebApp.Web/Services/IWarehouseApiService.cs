// GessiWebApp.Web/Services/IWarehouseApiService.cs
using GessiWebApp.API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GessiWebApp.Web.Services
{
    public interface IWarehouseApiService
    {
        Task<IEnumerable<WarehouseDto>> GetAllWarehousesAsync();
        Task<WarehouseDto> GetWarehouseByIdAsync(int id);
        Task<WarehouseDto> CreateWarehouseAsync(WarehouseDto warehouse);
        Task<WarehouseDto> UpdateWarehouseAsync(int id, WarehouseDto warehouse);
        Task DeleteWarehouseAsync(int id);
    }
}