using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechChallenge.GameStore.Domain.Jogos;
using TechChallenge.GameStore.Infrastructure.Jogos;
using TechChallenge.GameStore.Unit.Test._Shared;
using TechChallenge.GameStore.Unit.Test.Infrastructure.Jogos.Fakers;
using TechChallenge.GameStore.Unit.Test.Infrastructure.Jogos.Fixtures;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.Infrastructure.Jogos;

public class JogoRepositoryTest
{
    [Fact]
    public async Task ObterPorNome_QuandoJogoExiste_DeveRetornarJogo()
    {
        // Arrange
        using var fixture = new JogoRepositoryFixture();
        var jogo = JogoFaker.ComNome("Hollow Knight");
        await fixture.Context.Set<Jogo>().AddAsync(jogo);
        await fixture.Context.SaveChangesAsync();

        // Act
        var resultado = await fixture.Repository.ObterPorNome("HOLLOW KNIGHT");

        // Assert
        resultado.Should().NotBeNull();
        resultado!.Nome.Should().Be(jogo.Nome);
    }

    [Fact]
    public async Task ObterPorNome_QuandoJogoNaoExiste_DeveRetornarNull()
    {
        // Arrange
        using var fixture = new JogoRepositoryFixture();

        // Act
        var resultado = await fixture.Repository.ObterPorNome("NAO_EXISTE");

        // Assert
        resultado.Should().BeNull();
    }

    [Fact]
    public async Task ObterAsync_QuandoIdsExistem_DeveRetornarJogos()
    {
        // Arrange
        using var fixture = new JogoRepositoryFixture();
        var jogo1 = JogoFaker.ComNome("God of War");
        var jogo2 = JogoFaker.ComNome("Uncharted");

        await fixture.Context.Set<Jogo>().AddRangeAsync(jogo1, jogo2);
        await fixture.Context.SaveChangesAsync();

        var ids = new List<int> { jogo1.Id, jogo2.Id };

        // Act
        var jogos = await fixture.Repository.ObterAsync(ids);

        // Assert
        jogos.Should().HaveCount(2);
        jogos.Select(j => j.Id).Should().Contain(ids);
    }

    [Fact]
    public async Task AdicionarAsync_QuandoJogoValido_DevePersistir()
    {
        // Arrange
        using var fixture = new JogoRepositoryFixture();
        var jogo = JogoFaker.Valido();

        // Act
        var resultado = await fixture.Repository.AdicionarAsync(jogo);

        // Assert
        resultado.Sucesso.Should().BeTrue();
        resultado.Valor.Should().BeEquivalentTo(jogo);

        var persistido = await fixture.Context.Set<Jogo>().FindAsync(jogo.Id);
        persistido.Should().NotBeNull();
    }

    [Fact]
    public async Task AdicionarAsync_QuandoSalvarFalha_DeveRetornarErro()
    {
        // Arrange
        var context = ContextFactory.Create();
        var repository = new JogoRepository(context);
        
        context.Dispose();

        // Act
        var resultado = await repository.AdicionarAsync(JogoFaker.Valido());

        // Assert
        resultado.Sucesso.Should().BeFalse();
        resultado.Erro.Should().Contain("Erro ao salvar");
    }
}
