using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinX.Domain.Entities
{
    public class HistoricoMedico
    {
        public Guid Id { get; set; }
        public Guid PacienteId { get; set; }
        public string? Diagnostico { get; set; }
        public string? ExamesRealizados { get; set; }
        public string? Prescricao { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}
