using FluentAssertions;
using System.Threading.Tasks;
using TechChallenge.GameStore.Domain.Compras;
using TechChallenge.GameStore.Domain.Jogos;
using TechChallenge.GameStore.Unit.Test.Infrastructure.Compras.Fakers;
using TechChallenge.GameStore.Unit.Test.Infrastructure.Compras.Fixtures;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.Infrastructure.Compras;

public class BibliotecaJogosRepositoryTest : IClassFixture<BibliotecaJogosRepositoryFixture>
{
    private readonly BibliotecaJogosRepositoryFixture _fixture;

    public BibliotecaJogosRepositoryTest(BibliotecaJogosRepositoryFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task AdicionarAsync_QuandoValido_DevePersistir()
    {
        // Arrange
        var usuarioId = 1;
        var jogoId = 10;

        // Act
        await _fixture.Repository.AdicionarAsync(usuarioId, jogoId);

        // Assert
        var persisted = await _fixture.Context.Set<BibliotecaJogo>()
            .FindAsync(usuarioId, jogoId);

        persisted.Should().NotBeNull();
        persisted!.UsuarioId.Should().Be(usuarioId);
        persisted.JogoId.Should().Be(jogoId);
    }

    [Fact]
    public async Task UsuarioJaPossuiJogoAsync_QuandoExiste_DeveRetornarTrue()
    {
        // Arrange
        var usuarioId = 2;
        var jogoId = 20;
        var entidade = BibliotecaJogoFaker.Valido(usuarioId, jogoId);

        // Primeiro persiste o Jogo
        await _fixture.Context.Set<Jogo>().AddAsync(entidade.Jogo);
        await _fixture.Context.SaveChangesAsync();

        // Depois persiste o vínculo com o usuário
        await _fixture.Context.Set<BibliotecaJogo>().AddAsync(entidade);
        await _fixture.Context.SaveChangesAsync();

        // Act
        var resultado = await _fixture.Repository.UsuarioJaPossuiJogoAsync(usuarioId, jogoId);

        // Assert
        resultado.Should().BeTrue();
    }

}
