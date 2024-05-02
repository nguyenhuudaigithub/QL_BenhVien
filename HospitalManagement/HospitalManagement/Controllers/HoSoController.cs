using HospitalManagement.Data;
using HospitalManagement.Models;
using HospitalManagement.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoSoController : ControllerBase
    {
        private readonly IHoSoRepository _hoSoRepo;

        public HoSoController(IHoSoRepository repo)
        {
            _hoSoRepo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> GetHoSoModelAsync([FromBody]FetchHoSoModel model)
        {
            try
            {
                var hoSo = await _hoSoRepo.GetHoSoModelAsync(model);
                return hoSo == null ? NotFound() : Ok(hoSo);
            }
            catch
            {
                return BadRequest("Failed to get ho so.");
            }
        }
    }
}
