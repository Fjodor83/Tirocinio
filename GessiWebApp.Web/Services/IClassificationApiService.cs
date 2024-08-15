// GessiWebApp.Web/Services/IClassificationApiService.cs
using GessiWebApp.API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GessiWebApp.Web.Services
{
    public interface IClassificationApiService
    {
        Task<IEnumerable<ClassificationDto>> GetAllClassificationsAsync();
        Task<ClassificationDto> GetClassificationByIdAsync(int id);
        Task<ClassificationDto> CreateClassificationAsync(ClassificationCreateDto classification);
        Task<ClassificationDto> UpdateClassificationAsync(int id, ClassificationUpdateDto classification);
        Task DeleteClassificationAsync(int id);
    }
}