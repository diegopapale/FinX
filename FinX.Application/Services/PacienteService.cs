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
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _repo;

        public PacienteService(IPacienteRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<PacienteDto>> GetPacientesAsync()
        {
            var pacientes = await _repo.GetAllAsync();
            return pacientes.Select(p => new PacienteDto(p.Id, p.Nome, p.CPF, p.DataNascimento, p.Contato));
        }

        public async Task<PacienteDto?> GetPacienteByIdAsync(Guid id)
        {
            var paciente = await _repo.GetByIdAsync(id);
            if (paciente == null) return null;

            return new PacienteDto(paciente.Id, paciente.Nome, paciente.CPF, paciente.DataNascimento, paciente.Contato);
        }

        public async Task<Guid> CreatePacienteAsync(PacienteDto dto)
        {
            var paciente = new Paciente
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                CPF = dto.CPF,
                DataNascimento = dto.DataNascimento,
                Contato = dto.Contato
            };

            await _repo.CreateAsync(paciente);
            return paciente.Id;
        }

        public async Task UpdatePacienteAsync(Guid id, PacienteDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
            {
                throw new KeyNotFoundException("Paciente não encontrado.");
            }

            existing.Nome = dto.Nome;
            existing.CPF = dto.CPF;
            existing.DataNascimento = dto.DataNascimento;
            existing.Contato = dto.Contato;

            await _repo.UpdateAsync(existing);
        }

        public async Task DeletePacienteAsync(Guid id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
            {
                throw new KeyNotFoundException("Paciente não encontrado.");
            }

            await _repo.DeleteAsync(id);
        }
    }
}
