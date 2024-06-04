using HospitalManagement.Models;
using HospitalManagement.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "RequireDuocSi")]
    public class ThuocController : ControllerBase
    {
        private readonly IThuocRepository _thuocRepo;

        public ThuocController(IThuocRepository repo)
        {
            _thuocRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllThuocs()
        {
            try
            {
                var thuocs = await _thuocRepo.GetAllThuocsAsync();
                return Ok(thuocs);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetThuocById(int id)
        {
            try
            {
                var thuoc = await _thuocRepo.GetThuocAsync(id);
                return thuoc == null ? NotFound() : Ok(thuoc);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewThuoc([FromBody] ThuocModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var id = await _thuocRepo.AddThuocAsync(model);
                return CreatedAtAction(nameof(GetThuocById), new { id }, "Thuoc added successfully!");
            }
            catch
            {
                return StatusCode(500, "Failed to add new thuoc.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateThuoc(int id, [FromBody] ThuocModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _thuocRepo.UpdateThuocAsync(id, model);
                return NoContent();
            }
            catch
            {
                return StatusCode(500, "Failed to update thuoc.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThuoc(int id)
        {
            try
            {
                await _thuocRepo.DeleteThuocAsync(id);
                return NoContent();
            }
            catch
            {
                return StatusCode(500, "Failed to delete thuoc.");
            }
        }
    }
}
