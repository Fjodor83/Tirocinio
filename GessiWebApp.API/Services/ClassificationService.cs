using GessiWebApp.API.Data;
using GessiWebApp.API.DTOs;
using GessiWebApp.API.Models;
using GessiWebApp.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GessiWebApp.API.Services
{
    public class ClassificationService : IClassificationService
    {
        private readonly ApplicationDbContext _context;

        public ClassificationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClassificationDto>> GetAllClassificationsAsync()
        {
            return await _context.Classifications
                .Select(c => new ClassificationDto
                {
                    Id = c.Id,
                    ClassificationCode = c.Code,
                    ClassificationName = c.Name
                })
                .ToListAsync();
        }

        public async Task<ClassificationDto> GetClassificationByIdAsync(int id)
        {
            var classification = await _context.Classifications.FindAsync(id);

            if (classification == null) return null;

            return new ClassificationDto
            {
                Id = classification.Id,
                ClassificationCode = classification.Code,
                ClassificationName = classification.Name
            };
        }

        public async Task<ClassificationDto> CreateClassificationAsync(ClassificationCreateDto classificationDto)
        {
            var classification = new Classification
            {
                ClassificationCode = classificationDto.ClassificationCode,
                ClassificationName = classificationDto.ClassificationName
            };

            _context.Classifications.Add(classification);
            await _context.SaveChangesAsync();

            return new ClassificationDto
            {
                Id = classification.Id,
                ClassificationCode = classification.ClassificationCode,
                ClassificationName = classification.ClassificationName
            };
        }

        public async Task<ClassificationDto> UpdateClassificationAsync(int id, ClassificationUpdateDto classificationDto)
        {
            var classification = await _context.Classifications.FindAsync(id);

            if (classification == null) return null;

            classification.ClassificationCode = classificationDto.ClassificationCode;
            classification.ClassificationName = classificationDto.ClassificationName;

            _context.Classifications.Update(classification);
            await _context.SaveChangesAsync();

            return new ClassificationDto
            {
                Id = classification.Id,
                ClassificationCode = classification.ClassificationCode,
                ClassificationName = classification.ClassificationName
            };
        }

        public async Task DeleteClassificationAsync(int id)
        {
            var classification = await _context.Classifications.FindAsync(id);

            if (classification != null)
            {
                _context.Classifications.Remove(classification);
                await _context.SaveChangesAsync();
            }
        }

        Task<IEnumerable<ClassificationDto>> IClassificationService.GetAllClassificationsAsync()
        {
            throw new NotImplementedException();
        }

        Task<ClassificationDto> IClassificationService.GetClassificationByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ClassificationDto> CreateClassification(ClassificationCreateDto classificationDto)
        {
            throw new NotImplementedException();
        }

        public Task<ClassificationDto> UpdateClassification(int id, ClassificationUpdateDto classificationDto)
        {
            throw new NotImplementedException();
        }
    }
}
