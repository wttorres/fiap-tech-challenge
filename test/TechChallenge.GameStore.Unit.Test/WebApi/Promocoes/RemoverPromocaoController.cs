using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.GameStore.Application.Promocoes.Remover;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Unit.Test._Shared;
using TechChallenge.GameStore.Unit.Test.WebApi.Promocoes.Fakers;
using TechChallenge.GameStore.Unit.Test.WebApi.Promocoes.Fixtures;
using Xunit;
using RemoverPromocaoCommandFaker = TechChallenge.GameStore.Unit.Test.Application.Promocoes.Fakers.RemoverPromocaoCommandFaker;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Promocoes
{
    public class RemoverPromocaoControllerTest : RemoverPromocaoControllerFixture
    {
        [Fact]
        public async Task Cadastrar_QuandoRemocaoForBemSucedida_DeveRetornarOk()
        {
            // Arrange
            var command = RemoverPromocaoCommandFaker.ComIdValido();
            var result  = ResultFaker.Sucesso("Promoção removida com sucesso.");

            MediatorMock.ConfigurarSend(command, result);

            // Act
            var resultado = await Controller.Cadastrar(command) as OkObjectResult;

            // Assert
            resultado.Should().NotBeNull();
            MediatorMock.GarantirSend<RemoverPromocaoCommand, Result<string>>(x => x.PromocaoId == command.PromocaoId);

        }

        [Fact]
        public async Task Cadastrar_QuandoRemocaoFalhar_DeveRetornarBadRequest()
        {
            // Arrange
            var command = RemoverPromocaoCommandFaker.ComIdValido();
            var result = ResultFaker.Falha("Promoção não encontrada.");
            
            MediatorMock.ConfigurarSend(command, result);

            // Act
            var resultado = await Controller.Cadastrar(command) as BadRequestObjectResult;

            // Assert
            resultado.Should().NotBeNull();
            MediatorMock.GarantirSend<RemoverPromocaoCommand, Result<string>>(x => x.PromocaoId == command.PromocaoId);
        }
    }
}
