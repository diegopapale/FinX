using FinX.Domain.Entities;
using FinX.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace FinX.Infrastructure.Repositories
{
    public class HistoricoMedicoRepository : IHistoricoMedicoRepository
    {
        private readonly IDbConnection _connection;

        public HistoricoMedicoRepository(IConfiguration config)
        {
            _connection = new SqlConnection(config.GetConnectionString("Default"));
        }

        public async Task<IEnumerable<HistoricoMedico>> GetByPacienteIdAsync(Guid pacienteId)
        {
            var sql = "SELECT * FROM HistoricoMedico WHERE PacienteId = @PacienteId";
            return await _connection.QueryAsync<HistoricoMedico>(sql, new { PacienteId = pacienteId });
        }

        public async Task<HistoricoMedico?> GetByIdAsync(Guid id)
        {
            var sql = "SELECT * FROM HistoricoMedico WHERE Id = @Id";
            return await _connection.QueryFirstOrDefaultAsync<HistoricoMedico>(sql, new { Id = id });
        }

        public async Task CreateAsync(HistoricoMedico historico)
        {
            var sql = @"INSERT INTO HistoricoMedico (Id, PacienteId, Diagnostico, ExamesRealizados, Prescricao, DataRegistro)
                    VALUES (@Id, @PacienteId, @Diagnostico, @ExamesRealizados, @Prescricao, @DataRegistro)";
            await _connection.ExecuteAsync(sql, historico);
        }

        public async Task UpdateAsync(HistoricoMedico historico)
        {
            var sql = @"UPDATE HistoricoMedico SET 
                      Diagnostico = @Diagnostico, 
                      ExamesRealizados = @ExamesRealizados, 
                      Prescricao = @Prescricao 
                    WHERE Id = @Id";

            await _connection.ExecuteAsync(sql, historico);
        }

        public async Task DeleteAsync(Guid id)
        {
            var sql = "DELETE FROM HistoricoMedico WHERE Id = @Id";
            await _connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
