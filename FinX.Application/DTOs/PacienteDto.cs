using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinX.Application.DTOs
{
    public record PacienteDto(
        Guid Id,
        string Nome,
        string CPF,
        DateTime DataNascimento,
        string Contato
    );
}
