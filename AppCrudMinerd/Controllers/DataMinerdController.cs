using AppCrudMinerd.Application.Dtos;
using AppCrudMinerd.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppCrudMinerd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataMinerdController : ControllerBase
    {
        private readonly IDataMinerdService _service;

        public DataMinerdController(IDataMinerdService service)
        {
            _service = service;
        }

        // GET: api/DataMinerd
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataMinerdDto>>> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(list);
        }

        // GET: api/DataMinerd/{site}
        [HttpGet("{site}")]
        public async Task<ActionResult<DataMinerdDto>> GetById(string site)
        {
            var dto = await _service.GetByIdAsync(site);
            if (dto == null) return NotFound();
            return Ok(dto);
        }

        // POST: api/DataMinerd
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateDataMinerdDto dto)
        {
            // Aquí podrías validar ModelState.IsValid
            await _service.CreateAsync(dto);
            // Asumimos que dto.Site viene en la petición y es único
            return CreatedAtAction(nameof(GetById), new { site = dto.Site }, dto);
        }

        // PUT: api/DataMinerd/{site}
        [HttpPut("{site}")]
        public async Task<ActionResult> Update(string site, [FromBody] UpdateDataMinerdDto dto)
        {
            var existing = await _service.GetByIdAsync(site);
            if (existing == null) return NotFound();

            await _service.UpdateAsync(site, dto);
            return NoContent();
        }

        // DELETE: api/DataMinerd/{site}
        [HttpDelete("{site}")]
        public async Task<ActionResult> Delete(string site)
        {
            var existing = await _service.GetByIdAsync(site);
            if (existing == null) return NotFound();

            await _service.DeleteAsync(site);
            return NoContent();
        }
    }
}
