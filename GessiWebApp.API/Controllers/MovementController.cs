using GessiWebApp.API.DTOs;
using GessiWebApp.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GessiWebApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovementController : ControllerBase
    {
        private readonly IMovementService _movementService;

        public MovementController(IMovementService movementService)
        {
            _movementService = movementService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovementDto>>> GetMovements()
        {
            var movements = await _movementService.GetAllMovementsAsync();
            return Ok(movements);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovementDto>> GetMovement(int id)
        {
            var movement = await _movementService.GetMovementByIdAsync(id);
            if (movement == null)
            {
                return NotFound();
            }
            return Ok(movement);
        }

        [HttpPost]
        public async Task<ActionResult<MovementDto>> CreateMovement(MovementCreateDto movementDto)
        {
            var createdMovement = await _movementService.CreateMovementAsync(movementDto);
            return CreatedAtAction(nameof(GetMovement), new { id = createdMovement.Id }, createdMovement);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovement(int id)
        {
            await _movementService.DeleteMovementAsync(id);
            return NoContent();
        }
    }
}