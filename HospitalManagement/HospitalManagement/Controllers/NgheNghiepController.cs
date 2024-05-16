using HospitalManagement.Models;
using HospitalManagement.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NgheNghiepController : ControllerBase
    {
        private readonly INgheNghiepRepository _ngheNghiepRepo;

        public NgheNghiepController(INgheNghiepRepository repo)
        {
            _ngheNghiepRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNgheNghieps()
        {
            try
            {
                return Ok(await _ngheNghiepRepo.GetAllNgheNghiepsAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNgheNghiepById(int id)
        {
            var ngheNghiep = await _ngheNghiepRepo.GetNgheNghiepAsync(id);
            return ngheNghiep == null ? NotFound() : Ok(ngheNghiep);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewNgheNghiep(NgheNghiepModel model)
        {
            try
            {
                await _ngheNghiepRepo.AddNgheNghiepAsync(model);
                return Ok("Nghe nghiep added successfully!");
            }
            catch
            {
                return BadRequest("Failed to add new nghe nghiep.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNgheNghiep(int id, [FromBody] NgheNghiepModel model)
        {
            await _ngheNghiepRepo.UpdateNgheNghiepAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNgheNghiep([FromRoute] int id)
        {
            await _ngheNghiepRepo.DeleteNgheNghiepAsync(id);
            return Ok();
        }
    }
}
