using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.GameStore.Application.Compras.Consultar;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Unit.Test.WebApi.HistoricoCompras.Fakers;
using TechChallenge.GameStore.Unit.Test.WebApi.HistoricoCompras.Fixtures;
using Xunit;
using static TechChallenge.GameStore.Application.HistoricoCompras.HistoricoCompraResponse;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Compras;

public class ObterHistoricoComprasControllerTest : ConsultarHistoricoComprasControllerFixture
{
    [Fact]
    public async Task ObterHistorico_QuandoComprasEncontradas_DeveRetornarOk()
    {
        // Arrange
        var usuarioId = 5;
        var compras = HistoricoCompraResponseFaker.GerarListaCompras(2);
        var resultado = Result.Success(compras);
        var query = new ConsultaHistoricoComprasQuery(usuarioId);

        MediatorMock.ConfigurarEnvio(query, resultado);

        // Act
        var response = await Controller.ObterHistorico(usuarioId);

        // Assert
        var okResult = response.Should().BeOfType<OkObjectResult>().Subject;
        okResult.Value.Should().BeEquivalentTo(new
        {
            sucesso = true,
            compras
        });

        MediatorMock.GarantirEnvio(query);
    }

    [Fact]
    public async Task ObterHistorico_QuandoNaoHaCompras_DeveRetornarNotFound()
    {
        // Arrange
        var usuarioId = 77;
        var resultado = Result.Failure<List<CompraDto>>("Nenhuma compra encontrada para o usuário.");
        var query = new ConsultaHistoricoComprasQuery(usuarioId);

        MediatorMock.ConfigurarEnvio(query, resultado);

        // Act
        var response = await Controller.ObterHistorico(usuarioId);

        // Assert
        var notFound = response.Should().BeOfType<NotFoundObjectResult>().Subject;
        notFound.Value.Should().BeEquivalentTo(new
        {
            sucesso = false,
            mensagem = "Nenhuma compra encontrada para o usuário."
        });

        MediatorMock.GarantirEnvio(query);
    }
}
