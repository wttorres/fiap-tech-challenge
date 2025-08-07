using FluentAssertions;
using TechChallenge.GameStore.Domain.Compras;
using TechChallenge.GameStore.Domain.Jogos;
using TechChallenge.GameStore.Domain.Usuarios;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.Domain.Compras;

public class BibliotecaJogoTest
{
    [Fact]
    public void Instanciar_QuandoDadosValidos_DevePopularCorretamente()
    {
        // Arrange
        var usuario = Usuario.Criar("Usuário Teste", "teste@email.com", "Senha123@12").Valor!;
        var jogo = Jogo.Criar("God of War", 149.90m).Valor!;

        // Act
        var bibliotecaJogo = new BibliotecaJogo
        {
            UsuarioId = usuario.Id,
            Usuario = usuario,
            JogoId = jogo.Id,
            Jogo = jogo
        };

        // Assert
        bibliotecaJogo.UsuarioId.Should().Be(usuario.Id);
        bibliotecaJogo.Usuario.Should().Be(usuario);
        bibliotecaJogo.JogoId.Should().Be(jogo.Id);
        bibliotecaJogo.Jogo.Should().Be(jogo);
    }
}
