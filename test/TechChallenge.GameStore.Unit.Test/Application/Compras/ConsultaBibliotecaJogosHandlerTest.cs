using System.Threading.Tasks;
using FluentAssertions;
using TechChallenge.GameStore.Application.Compras.Consultar;
using TechChallenge.GameStore.Unit.Test.Application.Compras.Fakers;
using TechChallenge.GameStore.Unit.Test.Application.Compras.Fixtures;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.Application.Compras;

public class ConsultaBibliotecaJogosHandlerTest : ConsultaBibliotecaJogosHandlerFixture
{
    [Fact]
    public async Task Handle_QuandoUsuarioPossuiJogos_DeveRetornarLista()
    {
        // Arrange
        var usuarioId = 1;
        var jogos = BibliotecaJogoFaker.ListaParaUsuario(usuarioId);
        BibliotecaJogosRepositoryMock.ConfigurarObterPorUsuarioIdAsync(usuarioId, jogos);

        var query = new ConsultaBibliotecaJogosQuery(usuarioId);

        // Act
        var result = await Handler.Handle(query, default);

        // Assert
        result.Sucesso.Should().BeTrue();
        result.Valor.Should().HaveCount(jogos.Count);
    }
}
