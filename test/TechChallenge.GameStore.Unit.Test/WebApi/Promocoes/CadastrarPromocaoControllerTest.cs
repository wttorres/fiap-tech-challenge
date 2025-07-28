using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.GameStore.Application.Promocoes.Cadastar;
using TechChallenge.GameStore.Application.Promocoes.Remover;
using TechChallenge.GameStore.Domain._Shared;
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
        var command = CadastrarUsuarioCommandFaker.Valido();
        var result  = ResultFaker.Sucesso("PROMO123");

        MediatorMock.ConfigurarSend(command, result);

        // Act
        var response = await Controller.Cadastrar(command);

        // Assert
        var okResult = response.Should().BeOfType<OkObjectResult>().Subject;
        okResult.Value.Should().BeEquivalentTo(new
        {
            sucesso = true,
            mensagem = "Promoção cadastrada com sucesso.",
            valor = "PROMO123"
        });

        MediatorMock.GarantirSend<CadastrarPromocaoCommand, Result<string>>(x => x.Nome == command.Nome);
    }

    [Fact]
    public async Task Cadastrar_QuandoFalha_DeveRetornarBadRequest()
    {
        // Arrange
        var command = CadastrarUsuarioCommandFaker.Valido();
        var result  = ResultFaker.Falha("Erro ao cadastrar promoção");
        
        MediatorMock.ConfigurarSend(command, result);
        
        // Act
        var response = await Controller.Cadastrar(command);

        // Assert
        var badRequest = response.Should().BeOfType<BadRequestObjectResult>().Subject;
        badRequest.Value.Should().BeEquivalentTo(new
        {
            sucesso = false,
            mensagem = "Erro ao cadastrar promoção",
            valor = (string)null
        });

        MediatorMock.GarantirSend<CadastrarPromocaoCommand, Result<string>>(x => x.Nome == command.Nome);
    }
}