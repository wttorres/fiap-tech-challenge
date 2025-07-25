using System.Threading.Tasks;
using FluentAssertions;
using TechChallenge.GameStore.Domain.Promocoes;
using TechChallenge.GameStore.Infrastructure.Promocoes;
using TechChallenge.GameStore.Unit.Test._Shared;
using TechChallenge.GameStore.Unit.Test.Infrastructure.Promocoes.Fakers;
using TechChallenge.GameStore.Unit.Test.Infrastructure.Promocoes.Fixtures;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.Infrastructure.Promocoes;

public class PromocaoRepositoryTest 
{
    [Fact]
    public async Task ExisteAsync_QuandoPromocaoExiste_DeveRetornarTrue()
    {
        // Arrange
        using var fixture = new PromocaoRepositoryFixture();
        var promocao = PromocaoFaker.ComNome("Cyber Monday");
        await fixture.Context.Set<Promocao>().AddAsync(promocao);
        await fixture.Context.SaveChangesAsync();

        // Act
        var existe = await fixture.Repository.ExisteAsync("CYBER MONDAY");

        // Assert
        existe.Should().BeTrue();
    }

    [Fact]
    public async Task ExisteAsync_QuandoPromocaoNaoExiste_DeveRetornarFalse()
    {
        // Act
        using var fixture = new PromocaoRepositoryFixture();
        var existe = await fixture.Repository.ExisteAsync("NÃO EXISTE");

        // Assert
        existe.Should().BeFalse();
    }

    [Fact]
    public async Task AdicionarAsync_QuandoPromocaoValida_DevePersistir()
    {
        // Arrange
        using var fixture = new PromocaoRepositoryFixture();
        var promocao = PromocaoFaker.Valida();

        // Act
        var result = await fixture.Repository.AdicionarAsync(promocao);

        // Assert
        result.Sucesso.Should().BeTrue();
        result.Valor.Should().BeEquivalentTo(promocao);

        var persisted = await fixture.Context.Set<Promocao>().FindAsync(promocao.Id);
        persisted.Should().NotBeNull();
    }

    [Fact]
    public async Task AdicionarAsync_QuandoSalvarFalha_DeveRetornarErro()
    {
        // Arrange
        var context = ContextFactory.Create();
        var repository = new PromocaoRepository(context);

        // Força falha descartando o contexto
        context.Dispose();

        // Act
        var result = await repository.AdicionarAsync(PromocaoFaker.Valida());

        // Assert
        result.Sucesso.Should().BeFalse();
        result.Erro.Should().Contain("Erro ao salvar promoção");
    }
}
