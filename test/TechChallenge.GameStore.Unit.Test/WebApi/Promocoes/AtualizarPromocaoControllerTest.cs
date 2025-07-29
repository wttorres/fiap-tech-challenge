using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.GameStore.Application.Promocoes.Atualizar;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Unit.Test._Shared;
using TechChallenge.GameStore.Unit.Test.WebApi.Promocoes.Fakers;
using TechChallenge.GameStore.Unit.Test.WebApi.Promocoes.Fixtures;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Promocoes;

public class AtualizarPromocaoControllerTest : AtualizarPromocaoControllerFixture
{
    [Fact]
    public async Task Atualizar_QuandoAtualizacaoForBemSucedida_DeveRetornarOk()
    {
        // Arrange
        var command = AtualizarPromocaoCommandFaker.Valido();
        var result  = ResultFaker.Sucesso("promoção123");

        MediatorMock.ConfigurarSend(command, result);
        // Act
        var response = await Controller.Atualizar(command) as OkObjectResult;

        // Assert
        response.Should().NotBeNull();
        response!.StatusCode.Should().Be(200);
        MediatorMock.GarantirSend<AtualizarPromocaoCommand, Result<string>>(x => x.Nome == command.Nome);
    }

    [Fact]
    public async Task Atualizar_QuandoAtualizacaoFalhar_DeveRetornarBadRequest()
    {
        // Arrange
        var command = AtualizarPromocaoCommandFaker.Valido();
        var result  = ResultFaker.Falha("Erro ao atualizar");

        MediatorMock.ConfigurarSend(command, result);

        // Act
        var response = await Controller.Atualizar(command) as BadRequestObjectResult;

        // Assert
        response.Should().NotBeNull();
        response!.StatusCode.Should().Be(400);
        MediatorMock.GarantirSend<AtualizarPromocaoCommand, Result<string>>(x => x.Nome == command.Nome);
    }
}