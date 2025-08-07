using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.GameStore.Unit.Test._Shared;
using TechChallenge.GameStore.Unit.Test.WebApi.Compras.Fakers;
using TechChallenge.GameStore.Unit.Test.WebApi.Compras.Fixtures;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Compras;

public class ComprarJogoControllerTest : ComprarJogoControllerFixture
{
    [Fact]
    public async Task Comprar_QuandoSucesso_DeveRetornarOk()
    {
        // Arrange
        var comando = ComprarJogoCommandFaker.Valido();
        var resultado = ResultFaker.Sucesso("COMPRA123");

        MediatorMock.ConfigurarEnvio(comando, resultado);

        // Act
        var response = await Controller.Comprar(comando);

        // Assert
        var okResult = response.Should().BeOfType<OkObjectResult>().Subject;
        okResult.Value.Should().BeEquivalentTo(new
        {
            sucesso = true,
            mensagem = "Compra realizada com sucesso.",
            valor = "COMPRA123"
        });

        MediatorMock.GarantirEnvio(comando);
    }

    [Fact]
    public async Task Comprar_QuandoFalha_DeveRetornarBadRequest()
    {
        // Arrange
        var comando = ComprarJogoCommandFaker.Valido();
        var resultado = ResultFaker.Falha("Erro ao realizar compra");

        MediatorMock.ConfigurarEnvio(comando, resultado);

        // Act
        var response = await Controller.Comprar(comando);

        // Assert
        var badRequest = response.Should().BeOfType<BadRequestObjectResult>().Subject;
        badRequest.Value.Should().BeEquivalentTo(new
        {
            sucesso = false,
            mensagem = "Erro ao realizar compra",
            valor = (string)null
        });

        MediatorMock.GarantirEnvio(comando);
    }
}
