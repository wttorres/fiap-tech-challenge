using FluentAssertions;
using TechChallenge.GameStore.Domain.Notificacoes;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.Domain.Notificacoes;

public class NotificacaoEnviadaTest
{
    [Fact]
    public void Construtor_ComUsuarioIdEPromocaoJogoId_DeveInicializarCorretamente()
    {
        // Arrange
        var usuarioId = 10;
        var promocaoJogoId = 20;

        // Act
        var enviada = new NotificacaoEnviada(usuarioId, promocaoJogoId);

        // Assert
        enviada.UsuarioId.Should().Be(usuarioId);
        enviada.PromocaoJogoId.Should().Be(promocaoJogoId);
        enviada.NotificacaoId.Should().Be(0); 
        enviada.Notificacao.Should().BeNull();
        enviada.Usuario.Should().BeNull();
        enviada.PromocaoJogo.Should().BeNull();
    }
}