using Microsoft.AspNetCore.Mvc;
using StorageApp.BLL.Interfaces;
using StorageApp.DAL.Models;

namespace StorageApp.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class WarehousesController : ControllerBase
    {
        private readonly IWarehouseService _service;

        public WarehousesController(IWarehouseService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var warehouses = await _service.GetAllAsync();
            return Ok(warehouses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var warehouse = await _service.GetByIdAsync(id);

            if (warehouse == null)
                return NotFound();

            return Ok(warehouse);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Warehouse warehouse)
        {
            await _service.CreateAsync(warehouse);
            return Ok(warehouse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Warehouse warehouse)
        {
            if (id != warehouse.Id)
                return BadRequest("ID mismatch");

            await _service.UpdateAsync(warehouse);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
