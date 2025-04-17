using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinX.Application.DTOs
{
    public record HistoricoMedicoDto(
         Guid Id,
         Guid PacienteId,
         string? Diagnostico,
         string? ExamesRealizados,
         string? Prescricao,
         DateTime DataRegistro
     );
}
