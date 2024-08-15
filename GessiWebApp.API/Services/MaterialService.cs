using GessiWebApp.API.Data;
using GessiWebApp.API.DTOs;
using GessiWebApp.API.Models;
using GessiWebApp.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GessiWebApp.API.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly ApplicationDbContext _context;

        public MaterialService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MaterialDto>> GetAllMaterialsAsync()
        {
            return await _context.Materials
                .Include(m => m.Classifications)
                .Select(m => new MaterialDto
                {
                    Id = m.Id,
                    Code = m.Code,
                    Description = m.Description,
                    Notes = m.Notes,
                    Classifications = m.Classifications.Select(c => c.Name).ToList(),
                    Images = m.Images,
                    MainImage = m.MainImage,
                    CreationDate = m.CreationDate
                })
                .ToListAsync();
        }

        public async Task<MaterialDto> GetMaterialByIdAsync(int id)
        {
            var material = await _context.Materials
                .Include(m => m.Classifications)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (material == null) return null;

            return new MaterialDto
            {
                Id = material.Id,
                Code = material.Code,
                Description = material.Description,
                Notes = material.Notes,
                Classifications = material.Classifications.Select(c => c.Name).ToList(),
                Images = material.Images,
                MainImage = material.MainImage,
                CreationDate = material.CreationDate
            };
        }

        public async Task<MaterialDto> CreateMaterialAsync(MaterialCreateDto materialDto)
        {
            var material = new Material
            {
                Code = materialDto.Code,
                Description = materialDto.Description,
                Notes = materialDto.Notes,
                Images = materialDto.Images,
                MainImage = materialDto.MainImage,
                CreationDate = DateTime.UtcNow
            };

            var classifications = await _context.Classifications
                .Where(c => materialDto.Classifications.Contains(c.Name))
                .ToListAsync();
            material.Classifications = classifications;

            _context.Materials.Add(material);
            await _context.SaveChangesAsync();

            return new MaterialDto
            {
                Id = material.Id,
                Code = material.Code,
                Description = material.Description,
                Notes = material.Notes,
                Classifications = material.Classifications.Select(c => c.Name).ToList(),
                Images = material.Images,
                MainImage = material.MainImage,
                CreationDate = material.CreationDate
            };
        }

        public async Task<MaterialDto> UpdateMaterialAsync(int id, MaterialUpdateDto materialDto)
        {
            var material = await _context.Materials
                .Include(m => m.Classifications)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (material == null) return null;

            material.Code = materialDto.Code;
            material.Description = materialDto.Description;
            material.Notes = materialDto.Notes;
            material.Images = materialDto.Images;
            material.MainImage = materialDto.MainImage;

            var classifications = await _context.Classifications
                .Where(c => materialDto.Classifications.Contains(c.Name))
                .ToListAsync();
            material.Classifications = classifications;

            await _context.SaveChangesAsync();

            return new MaterialDto
            {
                Id = material.Id,
                Code = material.Code,
                Description = material.Description,
                Notes = material.Notes,
                Classifications = material.Classifications.Select(c => c.Name).ToList(),
                Images = material.Images,
                MainImage = material.MainImage,
                CreationDate = material.CreationDate
            };
        }

        public async Task DeleteMaterialAsync(int id)
        {
            var material = await _context.Materials.FindAsync(id);
            if (material != null)
            {
                _context.Materials.Remove(material);
                await _context.SaveChangesAsync();
            }
        }
    }
}