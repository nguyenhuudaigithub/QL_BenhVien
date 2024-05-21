using HospitalManagement.Data;
using HospitalManagement.Models;
using HospitalManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatLichController: ControllerBase
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
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDatLich(int id, [FromBody] DatLichModel model)
        {
            await _datLichRepository.UpdateDatLichAsync(id, model);
            return Ok();
        }
    }
}
