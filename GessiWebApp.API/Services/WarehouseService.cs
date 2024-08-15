using GessiWebApp.API.Data;
using GessiWebApp.API.DTOs;
using GessiWebApp.API.Models;
using GessiWebApp.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GessiWebApp.API.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly ApplicationDbContext _context;

        public WarehouseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WarehouseDto>> GetAllWarehousesAsync()
        {
            return await _context.Warehouses
                .Select(w => new WarehouseDto
                {
                    Id = w.Id,
                    Code = w.Code,
                    Name = w.Name,
                    Description = w.Description,
                    Notes = w.Notes
                })
                .ToListAsync();
        }

        public async Task<WarehouseDto> GetWarehouseByIdAsync(int id)
        {
            var warehouse = await _context.Warehouses.FindAsync(id);
            if (warehouse == null) return null;

            return new WarehouseDto
            {
                Id = warehouse.Id,
                Code = warehouse.Code,
                Name = warehouse.Name,
                Description = warehouse.Description,
                Notes = warehouse.Notes
            };
        }

        public async Task<WarehouseDto> CreateWarehouseAsync(WarehouseCreateDto warehouseDto)
        {
            var warehouse = new Warehouse
            {
                Code = warehouseDto.Code,
                Name = warehouseDto.Name,
                Description = warehouseDto.Description,
                Notes = warehouseDto.Notes
            };

            _context.Warehouses.Add(warehouse);
            await _context.SaveChangesAsync();

            return new WarehouseDto
            {
                Id = warehouse.Id,
                Code = warehouse.Code,
                Name = warehouse.Name,
                Description = warehouse.Description,
                Notes = warehouse.Notes
            };
        }

        public async Task<WarehouseDto> UpdateWarehouseAsync(int id, WarehouseUpdateDto warehouseDto)
        {
            var warehouse = await _context.Warehouses.FindAsync(id);
            if (warehouse == null) return null;

            warehouse.Code = warehouseDto.Code;
            warehouse.Name = warehouseDto.Name;
            warehouse.Description = warehouseDto.Description;
            warehouse.Notes = warehouseDto.Notes;

            await _context.SaveChangesAsync();

            return new WarehouseDto
            {
                Id = warehouse.Id,
                Code = warehouse.Code,
                Name = warehouse.Name,
                Description = warehouse.Description,
                Notes = warehouse.Notes
            };
        }

        public async Task DeleteWarehouseAsync(int id)
        {
            var warehouse = await _context.Warehouses.FindAsync(id);
            if (warehouse != null)
            {
                _context.Warehouses.Remove(warehouse);
                await _context.SaveChangesAsync();
            }
        }
    }
}