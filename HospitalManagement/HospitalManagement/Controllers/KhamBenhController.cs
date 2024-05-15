using HospitalManagement.Models;
using HospitalManagement.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    public class KhamBenhController
    {
        [Route("api/[controller]")]
        [ApiController]
        public class KhamBenhsController : ControllerBase
        {
            private readonly Repositories.IKhamBenhRepository<KhamBenh> _repository;

            public KhamBenhsController(IKhamBenhRepository<KhamBenh> repository)
            {
                _repository = repository;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<KhamBenh>>> GetKhamBenhs()
            {
                var khamBenhs = await _repository.GetAllAsync();
                return Ok(khamBenhs);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<KhamBenh>> GetKhamBenh(int id)
            {
                var khamBenh = await _repository.GetByIdAsync(id);
                if (khamBenh == null)
                {
                    return NotFound();
                }
                return Ok(khamBenh);
            }

            [HttpPost]
            public async Task<ActionResult<KhamBenh>> PostKhamBenh(KhamBenh khamBenh)
            {
                await _repository.AddAsync(khamBenh);
                return CreatedAtAction(nameof(GetKhamBenh), new { id = khamBenh.Id }, khamBenh);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> PutKhamBenh(int id, KhamBenh khamBenh)
            {
                if (id != khamBenh.Id)
                {
                    return BadRequest();
                }

                await _repository.UpdateAsync(khamBenh);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteKhamBenh(int id)
            {
                var exists = await _repository.ExistsAsync(id);
                if (!exists)
                {
                    return NotFound();
                }

                await _repository.DeleteAsync(id);
                return NoContent();
            }
        }
    }
}
