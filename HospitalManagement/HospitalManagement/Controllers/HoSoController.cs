using HospitalManagement.Models;
using HospitalManagement.Repositories;
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
        public async Task<IActionResult> GetHoSoModelAsync([FromBody] FetchHoSoModel model)
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

        [HttpGet("/tinh")]
        public async Task<IActionResult> GetTinhModelListAsync()
        {
            try
            {
                var tinhList = await _hoSoRepo.GetTinhModelListAsync();
                return tinhList == null ? NotFound() : Ok(tinhList);
            }
            catch
            {
                return BadRequest("Failed to get list tinh.");
            }
        }

        [HttpPost("/huyen")]
        public async Task<IActionResult> GetHuyenModelListAsync([FromBody] string idTinh)
        {
            try
            {
                var huyenList = await _hoSoRepo.GetHuyenModelListAsync(idTinh);
                return huyenList == null ? NotFound() : Ok(huyenList);
            }
            catch
            {
                return BadRequest("Failed to get list huyen.");
            }
        }

        [HttpPost("/phuong")]
        public async Task<IActionResult> GetPhuongModelListAsync([FromBody] string idHuyen)
        {
            try
            {
                var phuongList = await _hoSoRepo.GetPhuongModelListAsync(idHuyen);
                return phuongList == null ? NotFound() : Ok(phuongList);
            }
            catch
            {
                return BadRequest("Failed to get list phuong.");
            }
        }

        [HttpPost("/diachi")]
        public async Task<IActionResult> GetChiTietDiaChiModelAsync([FromBody] string idPhuong)
        {
            try
            {
                var chiTietDiaChi = await _hoSoRepo.GetChiTietDiaChiModelAsync(idPhuong);
                return chiTietDiaChi == null ? NotFound() : Ok(chiTietDiaChi);
            }
            catch
            {
                return BadRequest("Failed to get chi tiet dia chi.");
            }
        }
    }
}
