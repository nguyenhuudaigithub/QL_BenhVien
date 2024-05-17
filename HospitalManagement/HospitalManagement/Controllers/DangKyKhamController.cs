using HospitalManagement.Models;
using HospitalManagement.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DangKyKhamController : ControllerBase
    {
        private readonly IDangKyKhamBenhRepository _dangKyRepo;

        public DangKyKhamController(IDangKyKhamBenhRepository repo)
        {
            _dangKyRepo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> AddDangKy([FromBody] DangKyModel dangKyModel)
        {
            try
            {
                await _dangKyRepo.AddDangKyAsync(dangKyModel);
                return Ok("Dang ky added successfully!");
        }
            catch
            {
                return BadRequest("Failed to add new dang ky.");
    }
}

    }
}
