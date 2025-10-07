using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using TechChallenge.GameStore.Unit.Test.Application.Jogos.Atualizar.Fakers;
using TechChallenge.GameStore.Unit.Test.Application.Jogos.Atualizar.Fixtures;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.Application.Jogos.Atualizar;

public class AtualizarJogoHandlerTest : AtualizarJogoHandlerFixture
{
    [Fact]
    public async Task Handle_QuandoJogoNaoExiste_DeveRetornarFalha()
    {
        // Arrange
        var command = AtualizarJogoCommandFaker.Valido();
        JogoRepositoryMock.ConfigurarObterPorIdRetornando(null);

        // Act
        var resultado = await Handler.Handle(command, CancellationToken.None);

        // Assert
        resultado.Sucesso.Should().BeFalse();
        resultado.Erro.Should().Be("Jogo não encontrado.");
        JogoRepositoryMock.GarantirObterPorIdChamado(command.Id);
        JogoRepositoryMock.GarantirAtualizarNaoChamado();
    }

    [Fact]
    public async Task Handle_QuandoJogoExiste_DeveAtualizarEConfirmarSucesso()
    {
        // Arrange
        var command = AtualizarJogoCommandFaker.Valido();
        var jogo = JogoFaker.Valido();
        JogoRepositoryMock.ConfigurarObterPorIdRetornando(jogo);

        // Act
        var resultado = await Handler.Handle(command, CancellationToken.None);

        // Assert
        resultado.Sucesso.Should().BeTrue();
        resultado.Valor.Should().BeTrue();
        JogoRepositoryMock.GarantirObterPorIdChamado(command.Id);
        JogoRepositoryMock.GarantirAtualizarChamado(jogo);
    }
}