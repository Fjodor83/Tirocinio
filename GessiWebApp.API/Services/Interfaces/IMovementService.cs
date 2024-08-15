using GessiWebApp.API.DTOs;

namespace GessiWebApp.API.Services.Interfaces
{
    public interface IMovementService
    {
        Task<IEnumerable<MovementDto>> GetAllMovementsAsync();
        Task<MovementDto> GetMovementByIdAsync(int id);
        Task<MovementDto> CreateMovementAsync(MovementCreateDto movementDto);
        Task DeleteMovementAsync(int id);
    }
}