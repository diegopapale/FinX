using FinX.Application.DTOs;
using FinX.Domain.Entities;
using FinX.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinX.Application.Services
{
    public class HistoricoMedicoService : IHistoricoMedicoService
    {
        private readonly IHistoricoMedicoRepository _repo;

        public HistoricoMedicoService(IHistoricoMedicoRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<HistoricoMedicoDto>> GetByPacienteIdAsync(Guid pacienteId)
        {
            var lista = await _repo.GetByPacienteIdAsync(pacienteId);
            return lista.Select(x => new HistoricoMedicoDto(x.Id, x.PacienteId, x.Diagnostico, x.ExamesRealizados, x.Prescricao, x.DataRegistro));
        }

        public async Task<HistoricoMedicoDto?> GetByIdAsync(Guid id)
        {
            var h = await _repo.GetByIdAsync(id);
            if (h == null) return null;

            return new HistoricoMedicoDto(h.Id, h.PacienteId, h.Diagnostico, h.ExamesRealizados, h.Prescricao, h.DataRegistro);
        }

        public async Task<Guid> CreateAsync(HistoricoMedicoDto dto)
        {
            var novo = new HistoricoMedico
            {
                Id = Guid.NewGuid(),
                PacienteId = dto.PacienteId,
                Diagnostico = dto.Diagnostico,
                ExamesRealizados = dto.ExamesRealizados,
                Prescricao = dto.Prescricao,
                DataRegistro = DateTime.UtcNow
            };

            await _repo.CreateAsync(novo);
            return novo.Id;
        }

        public async Task UpdateAsync(Guid id, HistoricoMedicoDto dto)
        {
            var atual = await _repo.GetByIdAsync(id);
            if (atual == null) throw new KeyNotFoundException("Histórico não encontrado.");

            atual.Diagnostico = dto.Diagnostico;
            atual.ExamesRealizados = dto.ExamesRealizados;
            atual.Prescricao = dto.Prescricao;

            await _repo.UpdateAsync(atual);
        }

        public async Task DeleteAsync(Guid id)
        {
            var atual = await _repo.GetByIdAsync(id);
            if (atual == null) throw new KeyNotFoundException("Histórico não encontrado.");

            await _repo.DeleteAsync(id);
        }
    }
}
