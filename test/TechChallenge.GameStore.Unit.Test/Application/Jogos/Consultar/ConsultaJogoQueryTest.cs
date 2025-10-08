using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using TechChallenge.GameStore.Unit.Test.Application.Jogos.Consultar.Fakers;
using TechChallenge.GameStore.Unit.Test.Application.Jogos.Consultar.Fixtures;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.Application.Jogos.Consultar;

public class ConsultaJogoQueryTest : ConsultaJogoQueryFixture
{
    [Fact]
    public async Task ObterTodosAsync_QuandoChamado_DeveRetornarTodosJogosMapeados()
    {
        // Arrange
        var jogos = JogoFaker.ListaValida();
        JogoRepositoryMock.ConfigurarObterTodos(jogos);

        // Act
        var resultado = await Consulta.ObterTodosAsync();

        // Assert
        resultado.Should().HaveSameCount(jogos);
        resultado.Select(j => j.Id).Should().BeEquivalentTo(jogos.Select(j => j.Id));
        JogoRepositoryMock.GarantirObterTodosChamado();
    }

    [Fact]
    public async Task ObterPorIdAsync_QuandoJogoExiste_DeveRetornarMapeado()
    {
        // Arrange
        var jogo = JogoFaker.Valido();
        JogoRepositoryMock.ConfigurarObterPorId(jogo);

        // Act
        var resultado = await Consulta.ObterPorIdAsync(jogo.Id);

        // Assert
        resultado.Should().NotBeNull();
        resultado!.Id.Should().Be(jogo.Id);
        resultado.Nome.Should().Be(jogo.Nome);
        resultado.Preco.Should().Be(jogo.Preco);
        JogoRepositoryMock.GarantirObterPorIdChamado(jogo.Id);
    }

    [Fact]
    public async Task ObterPorIdAsync_QuandoJogoNaoExiste_DeveRetornarNull()
    {
        // Arrange
        JogoRepositoryMock.ConfigurarObterPorId(null);

        // Act
        var resultado = await Consulta.ObterPorIdAsync(999);

        // Assert
        resultado.Should().BeNull();
        JogoRepositoryMock.GarantirObterPorIdChamado(999);
    }
}