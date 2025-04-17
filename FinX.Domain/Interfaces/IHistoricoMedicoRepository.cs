using FinX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinX.Domain.Interfaces
{
    public interface IHistoricoMedicoRepository
    {
        Task<IEnumerable<HistoricoMedico>> GetByPacienteIdAsync(Guid pacienteId);
        Task<HistoricoMedico?> GetByIdAsync(Guid id);
        Task CreateAsync(HistoricoMedico historico);
        Task UpdateAsync(HistoricoMedico historico);
        Task DeleteAsync(Guid id);
    }
}
