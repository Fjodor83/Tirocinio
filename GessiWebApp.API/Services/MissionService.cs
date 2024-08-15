using GessiWebApp.API.Data;
using GessiWebApp.API.DTOs;
using GessiWebApp.API.Models;
using GessiWebApp.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GessiWebApp.API.Services
{
    public class MissionService : IMissionService
    {
        private readonly ApplicationDbContext _context;

        public MissionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MissionDto>> GetAllMissionsAsync()
        {
            return await _context.Missions
                .Include(m => m.Items)
                .ThenInclude(i => i.Material)
                .Select(m => new MissionDto
                {
                    Id = m.Id,
                    Code = m.Code,
                    DestinationType = m.DestinationType,
                    Description = m.Description,
                    Status = m.Status,
                    UserId = m.UserId,
                    Items = m.Items.Select(i => new MissionItemDto
                    {
                        MaterialId = i.MaterialId,
                        MaterialCode = i.Material.Code,
                        Quantity = i.Quantity
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<MissionDto> GetMissionByIdAsync(int id)
        {
            var mission = await _context.Missions
                .Include(m => m.Items)
                .ThenInclude(i => i.Material)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (mission == null) return null;

            return new MissionDto
            {
                Id = mission.Id,
                Code = mission.Code,
                DestinationType = mission.DestinationType,
                Description = mission.Description,
                Status = mission.Status,
                UserId = mission.UserId,
                Items = mission.Items.Select(i => new MissionItemDto
                {
                    MaterialId = i.MaterialId,
                    MaterialCode = i.Material.Code,
                    Quantity = i.Quantity
                }).ToList()
            };
        }

        public async Task<MissionDto> CreateMissionAsync(MissionCreateDto missionDto)
        {
            var mission = new Mission
            {
                Code = GenerateMissionCode(),
                DestinationType = missionDto.DestinationType,
                Description = missionDto.Description,
                Status = "Created",
                UserId = missionDto.UserId,
                Items = missionDto.Items.Select(i => new MissionItem
                {
                    MaterialId = i.MaterialId,
                    Quantity = i.Quantity
                }).ToList()
            };

            _context.Missions.Add(mission);
            await _context.SaveChangesAsync();

            return await GetMissionByIdAsync(mission.Id);
        }

        public async Task<MissionDto> UpdateMissionAsync(int id, MissionUpdateDto missionDto)
        {
            var mission = await _context.Missions
                .Include(m => m.Items)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (mission == null) return null;

            mission.DestinationType = missionDto.DestinationType;
            mission.Description = missionDto.Description;
            mission.Status = missionDto.Status;

            // Update items
            mission.Items.Clear();
            mission.Items = missionDto.Items.Select(i => new MissionItem
            {
                MaterialId = i.MaterialId,
                Quantity = i.Quantity
            }).ToList();

            await _context.SaveChangesAsync();

            return await GetMissionByIdAsync(mission.Id);
        }

        public async Task<bool> DeleteMissionAsync(int id)
        {
            var mission = await _context.Missions.FindAsync(id);
            if (mission == null) return false;

            _context.Missions.Remove(mission);
            await _context.SaveChangesAsync();

            return true;
        }

        private string GenerateMissionCode()
        {
            // Implementazione della generazione del codice della missione
            return $"MIS-{DateTime.UtcNow.Ticks}";
        }

        Task IMissionService.DeleteMissionAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
