using GessiWebApp.API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GessiWebApp.API.Services.Interfaces
{
    public interface IClassificationService
    {
        Task<IEnumerable<ClassificationDto>> GetAllClassificationsAsync();
        Task<ClassificationDto> GetClassificationByIdAsync(int id);
        Task<ClassificationDto> CreateClassificationAsync(ClassificationCreateDto classificationDto);
        Task<ClassificationDto> UpdateClassificationAsync(int id, ClassificationUpdateDto classificationDto);
        Task DeleteClassificationAsync(int id);
    }
}
