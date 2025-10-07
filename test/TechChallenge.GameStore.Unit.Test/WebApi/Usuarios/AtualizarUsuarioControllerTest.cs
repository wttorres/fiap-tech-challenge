using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Unit.Test.WebApi.Usuarios.Fakers;
using TechChallenge.GameStore.Unit.Test.WebApi.Usuarios.Fixtures;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Usuarios;

public class AtualizarUsuarioControllerTest : AtualizarUsuarioControllerFixture
{
    [Fact]
    public async Task Atualizar_QuandoSucesso_DeveRetornarOk()
    {
        // Arrange
        var comando = AtualizarCommandFaker.Valido();
        var result = Result.Success("123");
        MediatorMock.ConfigurarAtualizaSendParaRetornar(result);

        // Act
        var response = await Controller.Atualizar(comando);

        // Assert
        var ok = response as OkObjectResult;
        ok.Should().NotBeNull();
        ok!.Value.Should().BeEquivalentTo(new
        {
            sucesso = true
        });

        MediatorMock.GarantirEnvioDoAtualizaCommand();
    }

    [Fact]
    public async Task Atualizar_QuandoFalha_DeveRetornarNotFound()
    {
        // Arrange
        var comando = AtualizarCommandFaker.Valido();
        var result = Result.Failure<string>("Usuário não encontrado");
        MediatorMock.ConfigurarAtualizaSendParaRetornar(result);

        // Act
        var response = await Controller.Atualizar(comando);

        // Assert
        var notFoundObjectResult = response as NotFoundObjectResult;
        notFoundObjectResult.Should().NotBeNull();
        notFoundObjectResult!.Value.Should().BeEquivalentTo(new
        {
            sucesso = false
        });
        
        MediatorMock.GarantirEnvioDoAtualizaCommand();
    }
}