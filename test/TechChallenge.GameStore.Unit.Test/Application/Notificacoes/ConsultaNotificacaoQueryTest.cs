using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using TechChallenge.GameStore.Unit.Test.Application.Notificacoes.Fakers;
using TechChallenge.GameStore.Unit.Test.Application.Notificacoes.Fixtures;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.Application.Notificacoes;

public class ConsultaNotificacaoQueryTest : ConsultaNotificacaoQueryFixture
{
    [Fact]
    public async Task ObterTodasAsync_QuandoExistiremNotificacoes_DeveRetornarLista()
    {
        // Arrange
        var notificacoes = NotificacaoEnviadaFaker.ListaValida(2);
        NotificacaoRepositoryMock.ConfigurarObterTodasAsync(notificacoes);

        // Act
        var resultado = await ConsultaQuery.ObterTodasAsync();

        // Assert
        resultado.Should().HaveCount(2);
        resultado.Select(r => r.Titulo).Should().BeEquivalentTo(notificacoes.Select(n => n.Notificacao.Titulo));
        NotificacaoRepositoryMock.GarantirObterTodasAsyncChamado();
    }

    [Fact]
    public async Task ObterTodasAsync_QuandoNaoExistiremNotificacoes_DeveRetornarListaVazia()
    {
        // Arrange
        NotificacaoRepositoryMock.ConfigurarObterTodasAsync([]);

        // Act
        var resultado = await ConsultaQuery.ObterTodasAsync();

        // Assert
        resultado.Should().BeEmpty();
        NotificacaoRepositoryMock.GarantirObterTodasAsyncChamado();
    }

    [Fact]
    public async Task ObterPorIdUsuarioAsync_QuandoExistiremNotificacoes_DeveRetornarLista()
    {
        // Arrange
        var usuarioId = 99;
        var notificacoes = NotificacaoEnviadaFaker.ListaValida(3);
        NotificacaoRepositoryMock.ConfigurarObterPorUsuarioAsync(usuarioId, notificacoes);

        // Act
        var resultado = await ConsultaQuery.ObterPorIdUsuarioAsync(usuarioId);

        // Assert
        resultado.Should().HaveCount(3);
        resultado.Select(r => r.Mensagem).Should().BeEquivalentTo(notificacoes.Select(n => n.Notificacao.Mensagem));
        NotificacaoRepositoryMock.GarantirObterPorUsuarioAsyncChamado(usuarioId);
    }

    [Fact]
    public async Task ObterPorIdUsuarioAsync_QuandoNaoExistiremNotificacoes_DeveRetornarListaVazia()
    {
        // Arrange
        var usuarioId = 123;
        NotificacaoRepositoryMock.ConfigurarObterPorUsuarioAsync(usuarioId, []);

        // Act
        var resultado = await ConsultaQuery.ObterPorIdUsuarioAsync(usuarioId);

        // Assert
        resultado.Should().BeEmpty();
        NotificacaoRepositoryMock.GarantirObterPorUsuarioAsyncChamado(usuarioId);
    }
}
