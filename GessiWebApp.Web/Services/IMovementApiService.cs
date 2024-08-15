// GessiWebApp.Web/Services/IMovementApiService.cs
using GessiWebApp.API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GessiWebApp.Web.Services
{
    public interface IMovementApiService
    {
        Task<IEnumerable<MovementDto>> GetAllMovementsAsync();
        Task<MovementDto> GetMovementByIdAsync(int id);
        Task<MovementDto> CreateIncomingMovementAsync(MovementCreateDto movement);
        Task<MovementDto> CreateOutgoingMovementAsync(MovementCreateDto movement);
    }
}