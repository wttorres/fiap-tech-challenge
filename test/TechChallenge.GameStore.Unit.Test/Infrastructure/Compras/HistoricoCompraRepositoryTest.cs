using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TechChallenge.GameStore.Domain.Compras;
using TechChallenge.GameStore.Unit.Test.Infrastructure.Compras.Fakers;
using TechChallenge.GameStore.Unit.Test.Infrastructure.Compras.Fixtures;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.Infrastructure.Compras;

public class HistoricoCompraRepositoryTest : IClassFixture<HistoricoCompraRepositoryFixture>
{
    private readonly HistoricoCompraRepositoryFixture _fixture;

    public HistoricoCompraRepositoryTest(HistoricoCompraRepositoryFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task AdicionarAsync_QuandoCompraValida_DevePersistir()
    {
        // Arrange
        var compra = HistoricoCompraFaker.ParaUsuario(1);
        compra.Id = 0;

        // Act
        await _fixture.Repository.AdicionarAsync(compra);

        // Assert
        var persisted = await _fixture.Context.Set<HistoricoCompra>()
            .Include(h => h.Itens)
            .FirstOrDefaultAsync(h => h.UsuarioId == compra.UsuarioId);

        persisted.Should().NotBeNull();
        persisted!.UsuarioId.Should().Be(compra.UsuarioId);
        persisted.Itens.Should().HaveCount(compra.Itens.Count);
    }


    [Fact]
    public async Task ObterPorUsuarioIdAsync_QuandoExistemCompras_DeveRetornarLista()
    {
        // Arrange
        var usuarioId = 77;
        var compras = HistoricoCompraFaker.ListaParaUsuario(usuarioId);

        await _fixture.Context.Set<HistoricoCompra>().AddRangeAsync(compras);
        await _fixture.Context.SaveChangesAsync();

        // Act
        var resultado = await _fixture.Repository.ObterPorUsuarioIdAsync(usuarioId);

        // Assert
        resultado.Should().NotBeNullOrEmpty();
        resultado.Should().OnlyContain(c => c.UsuarioId == usuarioId);
        resultado.SelectMany(c => c.Itens).Should().NotBeEmpty();
    }
}
