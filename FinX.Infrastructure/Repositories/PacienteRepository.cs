using Dapper;
using FinX.Domain.Entities;
using FinX.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinX.Infrastructure.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly IDbConnection _connection;

        public PacienteRepository(IConfiguration configuration)
        {
            _connection = new SqlConnection(configuration.GetConnectionString("Default"));
        }

        public async Task<IEnumerable<Paciente>> GetAllAsync()
        {
            var sql = @"SELECT Id, Nome, CPF, DataNascimento, Contato FROM Pacientes";
            return await _connection.QueryAsync<Paciente>(sql);
        }

        public async Task<Paciente?> GetByIdAsync(Guid id)
        {
            var sql = @"SELECT Id, Nome, CPF, DataNascimento, Contato FROM Pacientes WHERE Id = @Id";
            return await _connection.QueryFirstOrDefaultAsync<Paciente>(sql, new { Id = id });
        }

        public async Task CreateAsync(Paciente paciente)
        {
            var sql = @"
            INSERT INTO Pacientes (Id, Nome, CPF, DataNascimento, Contato)
            VALUES (@Id, @Nome, @CPF, @DataNascimento, @Contato)";

            await _connection.ExecuteAsync(sql, new
            {
                paciente.Id,
                paciente.Nome,
                paciente.CPF,
                paciente.DataNascimento,
                paciente.Contato
            });
        }

        public async Task UpdateAsync(Paciente paciente)
        {
            var sql = @"
            UPDATE Pacientes 
            SET Nome = @Nome,
                CPF = @CPF,
                DataNascimento = @DataNascimento,
                Contato = @Contato
            WHERE Id = @Id";

            await _connection.ExecuteAsync(sql, new
            {
                paciente.Id,
                paciente.Nome,
                paciente.CPF,
                paciente.DataNascimento,
                paciente.Contato
            });
        }

        public async Task DeleteAsync(Guid id)
        {
            var sql = @"DELETE FROM Pacientes WHERE Id = @Id";
            await _connection.ExecuteAsync(sql, new { Id = id });
        }

    }
}
