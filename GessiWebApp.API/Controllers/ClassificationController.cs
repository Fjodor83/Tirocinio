using GessiWebApp.API.DTOs;
using GessiWebApp.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GessiWebApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassificationController : ControllerBase
    {
        private readonly IClassificationService _classificationService;

        public ClassificationController(IClassificationService classificationService)
        {
            _classificationService = classificationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassificationDto>>> GetAllClassifications()
        {
            var classifications = await _classificationService.GetAllClassificationsAsync();
            return Ok(classifications);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClassificationDto>> GetClassificationById(int id)
        {
            var classification = await _classificationService.GetClassificationByIdAsync(id);
            if (classification == null)
            {
                return NotFound();
            }
            return Ok(classification);
        }

        [HttpPost]
        public async Task<ActionResult<ClassificationDto>> CreateClassification(ClassificationCreateDto classificationCreateDto)
        {
            var createdClassification = await _classificationService.CreateClassificationAsync(classificationCreateDto);
            return CreatedAtAction(nameof(GetClassificationById), new { id = createdClassification.Id }, createdClassification);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClassificationDto>> UpdateClassification(int id, ClassificationUpdateDto classificationUpdateDto)
        {
            var updatedClassification = await _classificationService.UpdateClassificationAsync(id, classificationUpdateDto);
            if (updatedClassification == null)
            {
                return NotFound();
            }
            return Ok(updatedClassification);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassification(int id)
        {
            await _classificationService.DeleteClassificationAsync(id);
            return NoContent();
        }
    }
}
