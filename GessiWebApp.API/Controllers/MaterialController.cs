using GessiWebApp.API.DTOs;
using GessiWebApp.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GessiWebApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialDto>>> GetMaterials()
        {
            var materials = await _materialService.GetAllMaterialsAsync();
            return Ok(materials);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialDto>> GetMaterial(int id)
        {
            var material = await _materialService.GetMaterialByIdAsync(id);
            if (material == null)
            {
                return NotFound();
            }
            return Ok(material);
        }

        [HttpPost]
        public async Task<ActionResult<MaterialDto>> CreateMaterial(MaterialCreateDto materialDto)
        {
            var createdMaterial = await _materialService.CreateMaterialAsync(materialDto);
            return CreatedAtAction(nameof(GetMaterial), new { id = createdMaterial.Id }, createdMaterial);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaterial(int id, MaterialUpdateDto materialDto)
        {
            var updatedMaterial = await _materialService.UpdateMaterialAsync(id, materialDto);
            if (updatedMaterial == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterial(int id)
        {
            await _materialService.DeleteMaterialAsync(id);
            return NoContent();
        }
    }
}