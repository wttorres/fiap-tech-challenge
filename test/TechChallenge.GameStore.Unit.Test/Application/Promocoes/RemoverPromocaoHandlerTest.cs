using System.Threading.Tasks;
using FluentAssertions;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Unit.Test.Application.Promocoes.Fakers;
using TechChallenge.GameStore.Unit.Test.Application.Promocoes.Fixtures;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.Application.Promocoes;

public class RemoverPromocaoHandlerTest : RemoverPromocaoHandlerFixture
{
    [Fact]
    public async Task Handle_QuandoPromocaoNaoExiste_DeveRetornarFalha()
    {
        // Arrange
        var comando = RemoverPromocaoCommandFaker.ComIdValido();
        PromocaoRepositoryMock.ConfigurarObterPorId(null);

        // Act
        var result = await Handler.Handle(comando, default);

        // Assert
        result.Sucesso.Should().BeFalse();
        result.Erro.Should().Be("A promoção informada não existe");
        PromocaoRepositoryMock.GarantirConsultaPorId(comando.PromocaoId);
    }

    [Fact]
    public async Task Handle_QuandoRemocaoBemSucedida_DeveRetornarSucesso()
    {
        // Arrange
        var comando = RemoverPromocaoCommandFaker.ComIdValido();
        var promocao = PromocaoFaker.Valida();
        PromocaoRepositoryMock.ConfigurarObterPorId(promocao);
        PromocaoRepositoryMock.ConfigurarExcluir(promocao, Result.Success("removido"));

        // Act
        var result = await Handler.Handle(comando, default);

        // Assert
        result.Sucesso.Should().BeTrue();
        result.Valor.Should().Be("removido");
        PromocaoRepositoryMock.GarantirConsultaPorId(comando.PromocaoId);
        PromocaoRepositoryMock.GarantirExclusao(promocao);
    }

    [Fact]
    public async Task Handle_QuandoRemocaoFalha_DeveRetornarErro()
    {
        // Arrange
        var comando = RemoverPromocaoCommandFaker.ComIdValido();
        var promocao = PromocaoFaker.Valida();
        PromocaoRepositoryMock.ConfigurarObterPorId(promocao);
        PromocaoRepositoryMock.ConfigurarExcluir(promocao, Result.Failure<string>("erro ao excluir"));

        // Act
        var result = await Handler.Handle(comando, default);

        // Assert
        result.Sucesso.Should().BeFalse();
        result.Erro.Should().Be("erro ao excluir");
        PromocaoRepositoryMock.GarantirExclusao(promocao);
    }
}
