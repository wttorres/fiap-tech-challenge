using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.GameStore.Application.Autenticacao;
using TechChallenge.GameStore.Unit.Test.WebApi.Autenticacao.Fakers;
using TechChallenge.GameStore.Unit.Test.WebApi.Autenticacao.Fixtures;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Autenticacao;

public class LoginControllerTest : LoginControllerFixture
{
    [Fact]
    public async Task Login_QuandoRespostaValida_DeveRetornarOkComToken()
    {
        // Arrange
        var command = LoginCommandFaker.Valido();
        var expectedResponse = new LoginResponse()
        {
            Token = "fake-token"
        };

        MediatorMock.ConfigurarLoginComRetorno(expectedResponse);

        // Act
        var result = await Controller.Login(command);

        // Assert
        var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
        okResult.Value.Should().BeEquivalentTo(expectedResponse);

        MediatorMock.GarantirEnvioDeLogin();
    }

    [Fact]
    public async Task Login_QuandoRespostaNula_DeveRetornarUnauthorized()
    {
        // Arrange
        var command = LoginCommandFaker.Valido();

        MediatorMock.ConfigurarLoginComRetornoNulo();

        // Act
        var result = await Controller.Login(command);

        // Assert
        result.Should().BeOfType<UnauthorizedResult>();

        MediatorMock.GarantirEnvioDeLogin();
    }
}