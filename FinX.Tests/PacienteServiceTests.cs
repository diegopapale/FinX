using FinX.Application.Services;
using FinX.Domain.Entities;
using FinX.Domain.Interfaces;
using Moq;

namespace FinX.Tests;

public class PacienteServiceTests
{
    [Fact]
    public async Task Deve_Retornar_Lista_Vazia_Quando_Nao_Houver_Pacientes()
    {
        var repoMock = new Mock<IPacienteRepository>();
        repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Paciente>());

        var service = new PacienteService(repoMock.Object);
        var result = await service.GetPacientesAsync();

        Assert.Empty(result);
    }
}