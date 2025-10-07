using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Unit.Test.WebApi.Usuarios.Fakers;
using TechChallenge.GameStore.Unit.Test.WebApi.Usuarios.Fixtures;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Usuarios;

public class PromoverUsuarioControllerTest : PromoverUsuarioControllerFixture
{
    [Fact]
    public async Task Promover_QuandoSucesso_DeveRetornarOk()
    {
        // Arrange
        var comando = PromoverUsuarioCommandFaker.Valido();
        var resultado = Result.Success("123");
        MediatorMock.ConfigurarPromoveSendParaRetornar(resultado);

        // Act
        var response = await Controller.Promover(comando);

        // Assert
        var ok = response as OkObjectResult;
        ok.Should().NotBeNull();
        ok!.Value.Should().BeEquivalentTo(new
        {
            sucesso = true
        });

        MediatorMock.GarantirEnvioDoPromoveCommand();
    }

    [Fact]
    public async Task Promover_QuandoUsuarioNaoEncontrado_DeveRetornarNotFound()
    {
        // Arrange
        var comando = PromoverUsuarioCommandFaker.Valido();
        var resultado = Result.Failure<string>("Usuário não encontrado.");
        MediatorMock.ConfigurarPromoveSendParaRetornar(resultado);

        // Act
        var response = await Controller.Promover(comando);

        // Assert
        var notFoundObjectResult = response as NotFoundObjectResult;
        notFoundObjectResult.Should().NotBeNull();
        notFoundObjectResult!.Value.Should().BeEquivalentTo(new
        {
            sucesso = false
        });

        MediatorMock.GarantirEnvioDoPromoveCommand();
    }

    [Fact]
    public async Task Promover_QuandoErroGenerico_DeveRetornarBadRequest()
    {
        // Arrange
        var comando = PromoverUsuarioCommandFaker.Valido();
        var resultado = Result.Failure<string>("Permissão inválida.");
        MediatorMock.ConfigurarPromoveSendParaRetornar(resultado);

        // Act
        var response = await Controller.Promover(comando);

        // Assert
        var badRequest = response as BadRequestObjectResult;
        badRequest.Should().NotBeNull();
        badRequest!.Value.Should().BeEquivalentTo(new
        {
            sucesso = false
        });

        MediatorMock.GarantirEnvioDoPromoveCommand();
    }
}
