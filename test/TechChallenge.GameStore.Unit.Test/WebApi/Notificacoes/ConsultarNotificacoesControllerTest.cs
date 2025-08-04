using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.GameStore.Application.Notificacoes.Consultar;
using TechChallenge.GameStore.Unit.Test.WebApi.Notificacoes.Fakers;
using TechChallenge.GameStore.Unit.Test.WebApi.Notificacoes.Fixtures;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Notificacoes;

public class ConsultarNotificacoesControllerTest : ConsultarNotificacoesControllerFixture
{
    [Fact]
    public async Task ListarTodas_QuandoNotificacoesExistem_DeveRetornarOkComLista()
    {
        // Arrange
        var notificacoes = NotificacaoResponseFaker.ListaValida(3);
        ConsultaNotificacaoQueryMock.ConfigurarObterTodasAsync(notificacoes);

        // Act
        var resultado = await Controller.ListarTodas();

        // Assert
        var okResult = resultado.Should().BeOfType<OkObjectResult>().Subject;
        okResult.Value.Should().BeEquivalentTo(notificacoes);
        ConsultaNotificacaoQueryMock.GarantirObterTodasAsyncChamado();
    }

    [Fact]
    public async Task ObterPorIdUsuario_QuandoNaoExistemNotificacoes_DeveRetornarNotFound()
    {
        // Arrange
        var usuarioId = 123;
        var notificacoes = new List<NotificacaoResponse>();
        ConsultaNotificacaoQueryMock.ConfigurarObterPorIdUsuarioAsync(usuarioId, notificacoes);

        // Act
        var resultado = await Controller.ObterPorIdUsuario(usuarioId);

        // Assert
        var notFound = resultado.Should().BeOfType<NotFoundObjectResult>().Subject;
        notFound.Value.Should().BeEquivalentTo(new { mensagem = "Usuário não possui notificações." });
        ConsultaNotificacaoQueryMock.GarantirObterPorIdUsuarioAsyncChamado(usuarioId);
    }

    [Fact]
    public async Task ObterPorIdUsuario_QuandoExistemNotificacoes_DeveRetornarOkComLista()
    {
        // Arrange
        var usuarioId = 456;
        var notificacoes = NotificacaoResponseFaker.ListaValida(2);
        ConsultaNotificacaoQueryMock.ConfigurarObterPorIdUsuarioAsync(usuarioId, notificacoes);

        // Act
        var resultado = await Controller.ObterPorIdUsuario(usuarioId);

        // Assert
        var okResult = resultado.Should().BeOfType<OkObjectResult>().Subject;
        okResult.Value.Should().BeEquivalentTo(notificacoes);
        ConsultaNotificacaoQueryMock.GarantirObterPorIdUsuarioAsyncChamado(usuarioId);
    }
}
