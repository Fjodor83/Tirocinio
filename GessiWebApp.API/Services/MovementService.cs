using GessiWebApp.API.Data;
using GessiWebApp.API.DTOs;
using GessiWebApp.API.Models;
using GessiWebApp.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GessiWebApp.API.Services
{
    public class MovementService : IMovementService
    {
        private readonly ApplicationDbContext _context;

        public MovementService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MovementDto>> GetAllMovementsAsync()
        {
            return await _context.Movements
                .Include(m => m.Material)
                .Include(m => m.Warehouse)
                .Select(m => new MovementDto
                {
                    Id = m.Id,
                    MaterialId = m.MaterialId,
                    MaterialCode = m.Material.Code,
                    WarehouseId = m.WarehouseId,
                    WarehouseCode = m.Warehouse.Code,
                    Quantity = m.Quantity,
                    Date = m.Date,
                    Type = m.Type,
                    Notes = m.Notes
                })
                .ToListAsync();
        }

        public async Task<MovementDto> GetMovementByIdAsync(int id)
        {
            var movement = await _context.Movements
                .Include(m => m.Material)
                .Include(m => m.Warehouse)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movement == null) return null;

            return new MovementDto
            {
                Id = movement.Id,
                MaterialId = movement.MaterialId,
                MaterialCode = movement.Material.Code,
                WarehouseId = movement.WarehouseId,
                WarehouseCode = movement.Warehouse.Code,
                Quantity = movement.Quantity,
                Date = movement.Date,
                Type = movement.Type,
                Notes = movement.Notes
            };
        }

        public async Task<MovementDto> CreateMovementAsync(MovementCreateDto movementDto)
        {
            var movement = new Movement
            {
                MaterialId = movementDto.MaterialId,
                WarehouseId = movementDto.WarehouseId,
                Quantity = movementDto.Quantity,
                Date = DateTime.UtcNow,
                Type = movementDto.Type,
                Notes = movementDto.Notes
            };

            _context.Movements.Add(movement);
            await _context.SaveChangesAsync();

            return await GetMovementByIdAsync(movement.Id);
        }

        public async Task DeleteMovementAsync(int id)
        {
            var movement = await _context.Movements.FindAsync(id);
            if (movement != null)
            {
                _context.Movements.Remove(movement);
                await _context.SaveChangesAsync();
            }
        }
    }
}