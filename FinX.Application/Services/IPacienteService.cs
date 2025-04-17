using FinX.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinX.Application.Services
{
    public interface IPacienteService
    {
        Task<IEnumerable<PacienteDto>> GetPacientesAsync();
        Task<PacienteDto?> GetPacienteByIdAsync(Guid id);
        Task<Guid> CreatePacienteAsync(PacienteDto paciente);
        Task UpdatePacienteAsync(Guid id, PacienteDto paciente);
        Task DeletePacienteAsync(Guid id);
    }
}
