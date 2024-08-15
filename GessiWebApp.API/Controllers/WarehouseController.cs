using GessiWebApp.API.DTOs;
using GessiWebApp.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GessiWebApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WarehouseDto>>> GetWarehouses()
        {
            var warehouses = await _warehouseService.GetAllWarehousesAsync();
            return Ok(warehouses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WarehouseDto>> GetWarehouse(int id)
        {
            var warehouse = await _warehouseService.GetWarehouseByIdAsync(id);
            if (warehouse == null)
            {
                return NotFound();
            }
            return Ok(warehouse);
        }

        [HttpPost]
        public async Task<ActionResult<WarehouseDto>> CreateWarehouse(WarehouseCreateDto warehouseDto)
        {
            var createdWarehouse = await _warehouseService.CreateWarehouseAsync(warehouseDto);
            return CreatedAtAction(nameof(GetWarehouse), new { id = createdWarehouse.Id }, createdWarehouse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWarehouse(int id, WarehouseUpdateDto warehouseDto)
        {
            var updatedWarehouse = await _warehouseService.UpdateWarehouseAsync(id, warehouseDto);
            if (updatedWarehouse == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWarehouse(int id)
        {
            await _warehouseService.DeleteWarehouseAsync(id);
            return NoContent();
        }
    }
}