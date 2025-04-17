using FinX.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinX.Application.Services
{
    public interface IHistoricoMedicoService
    {
        Task<IEnumerable<HistoricoMedicoDto>> GetByPacienteIdAsync(Guid pacienteId);
        Task<HistoricoMedicoDto?> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(HistoricoMedicoDto dto);
        Task UpdateAsync(Guid id, HistoricoMedicoDto dto);
        Task DeleteAsync(Guid id);
    }
}
