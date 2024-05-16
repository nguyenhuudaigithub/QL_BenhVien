using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HospitalManagement.Models;
using HospitalManagement.Repositories;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuocTichController : ControllerBase
    {
        private readonly IQuocTichRepository _QuocTichRepo;

        public QuocTichController(IQuocTichRepository repo)
        {
            _QuocTichRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuocTichs()
        {
            try
            {
                return Ok(await _QuocTichRepo.GetAllQuocTichsAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuocTichById(int id)
        {
            var QuocTich = await _QuocTichRepo.GetQuocTichAsync(id);
            return QuocTich == null ? NotFound() : Ok(QuocTich);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewQuocTich(QuocTichModel model)
        {
            try
            {
                await _QuocTichRepo.AddQuocTichAsync(model);
                return Ok("Quoc Tich added successfully!");
            }
            catch
            {
                return BadRequest("Failed to add new Quoc Tich.");
            }
        }




        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuocTich(int id, [FromBody] QuocTichModel model)
        {
            await _QuocTichRepo.UpdateQuocTichAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuocTich([FromRoute] int id)
        {
            await _QuocTichRepo.DeleteQuocTichAsync(id);
            return Ok();
        }
    }
}
