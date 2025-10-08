using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Unit.Test.WebApi.Usuarios.Fakers;
using TechChallenge.GameStore.Unit.Test.WebApi.Usuarios.Fixtures;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Usuarios;

public class CadastrarUsuarioControllerTest : CadastrarUsuarioControllerFixture
{
    [Fact]
    public async Task Cadastrar_QuandoSucesso_DeveRetornarOk()
    {
        // Arrange
        var command = CadastrarCommandFaker.Valido();
        var result = Result.Success("123");

        MediatorMock.ConfigurarCadastroSendParaRetornar(result);

        // Act
        var response = await Controller.Cadastrar(command);

        // Assert
        var ok = response as OkObjectResult;
        ok.Should().NotBeNull();
        ok!.Value.Should().BeEquivalentTo(new
        {
            sucesso = true,
            mensagem = "Usuário cadastrado com sucesso.",
            valor = "123"
        });

        MediatorMock.GarantirEnvioDoCadastroCommand();
    }

    [Fact]
    public async Task Cadastrar_QuandoErro_DeveRetornarBadRequest()
    {
        // Arrange
        var command = CadastrarCommandFaker.Valido();
        var result = Result.Failure<string>("Falha ao cadastrar");

        MediatorMock.ConfigurarCadastroSendParaRetornar(result);

        // Act
        var response = await Controller.Cadastrar(command);

        // Assert
        var badRequest = response as BadRequestObjectResult;
        badRequest.Should().NotBeNull();
        badRequest!.Value.Should().BeEquivalentTo(new
        {
            sucesso = false,
            mensagem = "Falha ao cadastrar",
            valor = (string?)null
        });

        MediatorMock.GarantirEnvioDoCadastroCommand();
    }
}