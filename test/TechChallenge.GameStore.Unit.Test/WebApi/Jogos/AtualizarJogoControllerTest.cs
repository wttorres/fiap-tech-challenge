using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.GameStore.Unit.Test._Shared;
using TechChallenge.GameStore.Unit.Test.WebApi.Jogos.Fakers;
using TechChallenge.GameStore.Unit.Test.WebApi.Jogos.Fixtures;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Jogos;

public class AtualizarJogoControllerTest : AtualizarJogoControllerFixture
{
    [Fact]
    public async Task Atualizar_QuandoComandoValido_DeveRetornarOk()
    {
        // Arrange
        var comando = AtualizarJogoCommandFaker.Valido();
        var resultado = ResultFaker.Sucesso();
        
        MediatorMock.ConfigurarEnvio(comando, resultado);

        // Act
        var response = await Controller.Atualizar(comando);

        // Assert
        var okResult = response.Should().BeOfType<OkObjectResult>().Subject;
        okResult.Value.Should().BeEquivalentTo(new
        {
            sucesso = true
        });

        MediatorMock.GarantirEnvio(comando);
    }

    [Fact]
    public async Task Atualizar_QuandoComandoInvalido_DeveRetornarBadRequest()
    {
        // Arrange
        var comando = AtualizarJogoCommandFaker.Valido();
        var resultado = ResultFaker.FalhaBool("Erro ao atualizar jogo");
            
        MediatorMock.ConfigurarEnvio(comando, resultado);
        
        // Act
        var response = await Controller.Atualizar(comando);

        // Assert
        var badRequest = response.Should().BeOfType<BadRequestObjectResult>().Subject;
        badRequest.Value.Should().BeEquivalentTo(new
        {
            sucesso = false
        });

        MediatorMock.GarantirEnvio(comando);
    }
}