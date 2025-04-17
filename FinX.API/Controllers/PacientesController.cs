using FinX.Application.DTOs;
using FinX.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinX.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Protege todos os endpoints com JWT
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteService _service;

        public PacientesController(IPacienteService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna todos os pacientes cadastrados.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pacientes = await _service.GetPacientesAsync();
            return Ok(pacientes);
        }

        /// <summary>
        /// Retorna um paciente pelo ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var paciente = await _service.GetPacienteByIdAsync(id);
            if (paciente == null)
                return NotFound();

            return Ok(paciente);
        }

        /// <summary>
        /// Cadastra um novo paciente.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PacienteDto dto)
        {
            var id = await _service.CreatePacienteAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, dto);
        }

        /// <summary>
        /// Atualiza os dados de um paciente existente.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] PacienteDto dto)
        {
            try
            {
                await _service.UpdatePacienteAsync(id, dto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Exclui um paciente pelo ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _service.DeletePacienteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Consulta exames externos de um paciente usando CPF (mockado).
        /// </summary>
        [HttpGet("{cpf}/exames")]
        public IActionResult ConsultarExamesExternos(string cpf)
        {
            var examesMock = new[]
            {
                new { Nome = "Hemograma Completo", Data = DateTime.Today.AddDays(-10) },
                new { Nome = "Raio-X de Tórax", Data = DateTime.Today.AddDays(-7) },
                new { Nome = "Ultrassom", Data = DateTime.Today.AddDays(-2) }
            };

            return Ok(new
            {
                CPF = cpf,
                Exames = examesMock
            });
        }
    }
}
