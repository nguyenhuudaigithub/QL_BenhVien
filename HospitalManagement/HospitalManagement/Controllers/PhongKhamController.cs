using HospitalManagement.Models;
using HospitalManagement.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhongKhamController : ControllerBase
    {
        private readonly IPhongKhamRepository _phongKhamRepo;

        public PhongKhamController(IPhongKhamRepository repo)
        {
            _phongKhamRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPhongKhams()
        {
            try
            {
                return Ok(await _phongKhamRepo.GetAllPhongKhamsAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhongKhamById(int id)
        {
            var phongKham = await _phongKhamRepo.GetPhongKhamAsync(id);
            return phongKham == null ? NotFound() : Ok(phongKham);
        }

        [HttpPost]
        //[Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> AddNewPhongKham(PhongKhamModel model)
        {
            try
            {
                await _phongKhamRepo.AddPhongKhamAsync(model);
                return Ok("Phong kham added successfully!");
            }
            catch
            {
                return BadRequest("Failed to add new phong kham.");
            }
        }




        [HttpPut("{id}")]
        [Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> UpdatePhongKham(int id, [FromBody] PhongKhamModel model)
        {
            await _phongKhamRepo.UpdatePhongKhamAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> DeletePhongKham([FromRoute] int id)
        {
            await _phongKhamRepo.DeletePhongKhamAsync(id);
            return Ok();
        }
    }
}
