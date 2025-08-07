using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.GameStore.Application.Compras.Consultar;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Unit.Test.WebApi.Compras.Fakers;
using TechChallenge.GameStore.Unit.Test.WebApi.Compras.Fixtures;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Compras;

public class ConsultarBibliotecaJogosControllerTest : ConsultarBibliotecaJogosControllerFixture
{
    [Fact]
    public async Task ListarJogosAdquiridos_QuandoJogosEncontrados_DeveRetornarOk()
    {
        // Arrange
        var usuarioId = 1;
        var jogos = JogoAdquiridoResponseFaker.GerarLista(3);
        var resultado = Result.Success(jogos);
        var query = new ConsultaBibliotecaJogosQuery(usuarioId);

        MediatorMock.ConfigurarEnvio(query, resultado);

        // Act
        var response = await Controller.ListarJogosAdquiridos(usuarioId);

        // Assert
        var okResult = response.Should().BeOfType<OkObjectResult>().Subject;
        okResult.Value.Should().BeEquivalentTo(new
        {
            sucesso = true,
            jogos
        });

        MediatorMock.GarantirEnvio(query);
    }

    [Fact]
    public async Task ListarJogosAdquiridos_QuandoNenhumJogoEncontrado_DeveRetornarNotFound()
    {
        // Arrange
        var usuarioId = 99;
        var resultado = Result.Failure<List<JogoAdquiridoResponse>>("Nenhum jogo encontrado para o usuário.");
        var query = new ConsultaBibliotecaJogosQuery(usuarioId);

        MediatorMock.ConfigurarEnvio(query, resultado);

        // Act
        var response = await Controller.ListarJogosAdquiridos(usuarioId);

        // Assert
        var notFound = response.Should().BeOfType<NotFoundObjectResult>().Subject;
        notFound.Value.Should().BeEquivalentTo(new
        {
            sucesso = false,
            mensagem = "Nenhum jogo encontrado para o usuário."
        });

        MediatorMock.GarantirEnvio(query);
    }
}
