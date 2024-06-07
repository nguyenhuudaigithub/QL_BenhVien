using HospitalManagement.Models;
using HospitalManagement.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DatLichController : ControllerBase
    {
        private readonly IDatLichRepository _datLichRepository;

        public DatLichController(IDatLichRepository repo)
        {
            _datLichRepository = repo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDatLichById(int id)
        {
            var datLich = await _datLichRepository.GetDatLichAsync(id);
            return datLich == null ? NotFound() : Ok(datLich);
        }

        [HttpPost]
        public async Task<IActionResult> GetDatLichBySDTAndMaHoSo([FromBody] FetchDatLich fetchDatLich)
        {
            var datLich = await _datLichRepository.GetDatLichBySDTAndMaHoSoAsync(fetchDatLich.MaHoSo, fetchDatLich.SDT);
            return datLich == null ? NotFound() : Ok(datLich);
        }

        [Authorize(Policy = "RequireBacSi")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDatLich(int id, [FromBody] DatLichModel model)
        {
            await _datLichRepository.UpdateDatLichAsync(id, model);
            return Ok();
        }
    }
}
