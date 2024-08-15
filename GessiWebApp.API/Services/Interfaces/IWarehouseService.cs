using GessiWebApp.API.DTOs;

namespace GessiWebApp.API.Services.Interfaces
{
    public interface IWarehouseService
    {
        Task<IEnumerable<WarehouseDto>> GetAllWarehousesAsync();
        Task<WarehouseDto> GetWarehouseByIdAsync(int id);
        Task<WarehouseDto> CreateWarehouseAsync(WarehouseCreateDto warehouseDto);
        Task<WarehouseDto> UpdateWarehouseAsync(int id, WarehouseUpdateDto warehouseDto);
        Task DeleteWarehouseAsync(int id);
    }
}