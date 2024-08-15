using GessiWebApp.API.DTOs;
using GessiWebApp.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GessiWebApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MissionController : ControllerBase
    {
        private readonly IMissionService _missionService;

        public MissionController(IMissionService missionService)
        {
            _missionService = missionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MissionDto>>> GetAllMissions()
        {
            var missions = await _missionService.GetAllMissionsAsync();
            return Ok(missions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MissionDto>> GetMissionById(int id)
        {
            var mission = await _missionService.GetMissionByIdAsync(id);
            if (mission == null)
            {
                return NotFound();
            }
            return Ok(mission);
        }

        [HttpPost]
        public async Task<ActionResult<MissionDto>> CreateMission(MissionCreateDto missionCreateDto)
        {
            var createdMission = await _missionService.CreateMissionAsync(missionCreateDto);
            return CreatedAtAction(nameof(GetMissionById), new { id = createdMission.Id }, createdMission);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MissionDto>> UpdateMission(int id, MissionUpdateDto missionUpdateDto)
        {
            var updatedMission = await _missionService.UpdateMissionAsync(id, missionUpdateDto);
            if (updatedMission == null)
            {
                return NotFound();
            }
            return Ok(updatedMission);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMission(int id)
        {
            await _missionService.DeleteMissionAsync(id);
            return NoContent();
        }
    }
}
