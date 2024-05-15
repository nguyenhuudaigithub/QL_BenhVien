using HospitalManagement.Models;
using HospitalManagement.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanTocController : ControllerBase
    {
        private readonly IDanTocRepository _danTocRepo;

        public DanTocController(IDanTocRepository repo)
        {
            _danTocRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDanTocs()
        {
            try
            {
                return Ok(await _danTocRepo.GetAllDanTocsAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDanTocById(int id)
        {
            var danToc = await _danTocRepo.GetDanTocAsync(id);
            return danToc == null ? NotFound() : Ok(danToc);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewDanToc(DanTocModel model)
        {
            try
            {
                await _danTocRepo.AddDanTocAsync(model);
                return Ok("Dan toc added successfully!");
            }
            catch
            {
                return BadRequest("Failed to add new dan toc.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDanToc(int id, [FromBody] DanTocModel model)
        {
            await _danTocRepo.UpdateDanTocAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDanToc([FromRoute] int id)
        {
            await _danTocRepo.DeleteDanTocAsync(id);
            return Ok();
        }
    }
}
