using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.GameStore.Unit.Test._Shared;
using TechChallenge.GameStore.Unit.Test.WebApi.Promocoes.Fakers;
using TechChallenge.GameStore.Unit.Test.WebApi.Promocoes.Fixtures;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Promocoes;

public class CadastrarPromocaoControllerTest : CadastrarPromocaoControllerFixture
{
    [Fact]
    public async Task Cadastrar_QuandoSucesso_DeveRetornarOk()
    {
        // Arrange
        var comando = CadastrarUsuarioCommandFaker.Valido();
        var resultado = ResultFaker.Sucesso("PROMO123");

        MediatorMock.ConfigurarEnvio(comando, resultado);

        // Act
        var response = await Controller.Cadastrar(comando);

        // Assert
        var okResult = response.Should().BeOfType<OkObjectResult>().Subject;
        okResult.Value.Should().BeEquivalentTo(new
        {
            sucesso = true,
            mensagem = "Promoção cadastrada com sucesso.",
            valor = "PROMO123"
        });

        MediatorMock.GarantirEnvio(comando);
    }

    [Fact]
    public async Task Cadastrar_QuandoFalha_DeveRetornarBadRequest()
    {
        // Arrange
        var comando = CadastrarUsuarioCommandFaker.Valido();
        var resultado = ResultFaker.Falha("Erro ao cadastrar promoção");

        MediatorMock.ConfigurarEnvio(comando, resultado);

        // Act
        var response = await Controller.Cadastrar(comando);

        // Assert
        var badRequest = response.Should().BeOfType<BadRequestObjectResult>().Subject;
        badRequest.Value.Should().BeEquivalentTo(new
        {
            sucesso = false,
            mensagem = "Erro ao cadastrar promoção",
            valor = (string)null
        });

        MediatorMock.GarantirEnvio(comando);
    }
}