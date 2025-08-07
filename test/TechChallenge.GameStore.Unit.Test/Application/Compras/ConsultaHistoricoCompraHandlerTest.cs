using FluentAssertions;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechChallenge.GameStore.Application.Compras.Consultar;
using TechChallenge.GameStore.Domain.Compras;
using TechChallenge.GameStore.Unit.Test.Application.Compras.Fakers;
using TechChallenge.GameStore.Unit.Test.Application.Compras.Fixtures;
using TechChallenge.GameStore.Unit.Test.Infrastructure.Jogos.Fakers;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.Application.Compras;

public class ConsultaHistoricoCompraHandlerTest : ConsultaHistoricoCompraHandlerFixture
{
    [Fact]
    public async Task Handle_QuandoUsuarioPossuiCompras_DeveRetornarLista()
    {
        // Arrange
        var usuarioId = 1;
        var jogos = JogoFaker.Lista(new List<int> { 1, 2 });
        var compra = HistoricoCompraFaker.ParaUsuarioComJogos(usuarioId, jogos);

        HistoricoCompraRepositoryMock.ConfigurarObterPorUsuarioIdAsync(usuarioId, new List<HistoricoCompra> { compra });

        var query = new ConsultaHistoricoComprasQuery(usuarioId);

        // Act
        var result = await Handler.Handle(query, default);

        // Assert
        result.Sucesso.Should().BeTrue();
        result.Valor.Should().NotBeNull();
        result.Valor.Should().HaveCount(2);
    }
}
