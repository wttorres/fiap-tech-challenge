using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using TechChallenge.GameStore.Application.Promocoes.Consultar;
using TechChallenge.GameStore.Domain.Promocoes;
using TechChallenge.GameStore.Unit.Test.Application.Promocoes.Fakers;
using TechChallenge.GameStore.Unit.Test.Application.Promocoes.Fixtures;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.Application.Promocoes;

public class ConsultaPromocaoQueryTest : ConsultaPromocaoQueryFixture
{
    [Fact]
    public async Task ObterTodasAsync_QuandoChamado_DeveRetornarListaMapeada()
    {
        // Arrange
        var promocoes = new List<Promocao> { PromocaoFaker.Gerar(), PromocaoFaker.Gerar() };
        PromocaoRepositoryMock.ConfigurarObterTodasAsync(promocoes);

        // Act
        var resultado = await ConsultaQuery.ObterTodasAsync();

        // Assert
        resultado.Should().HaveCount(2);
        resultado.Should().AllBeOfType<PromocaoResponse>();
    }

    [Fact]
    public async Task ObterPorIdAsync_QuandoPromocaoExistir_DeveRetornarMapeada()
    {
        // Arrange
        var promocao = PromocaoFaker.Gerar();
        PromocaoRepositoryMock.ConfigurarObterPorIdAsync(promocao);

        // Act
        var resultado = await ConsultaQuery.ObterPorIdAsync(1);

        // Assert
        resultado.Should().NotBeNull();
        resultado!.Id.Should().Be(promocao.Id);
        resultado.Nome.Should().Be(promocao.Nome);
        resultado.Jogos.Should().HaveCount(promocao.Jogos.Count);
    }

    [Fact]
    public async Task ObterPorIdAsync_QuandoPromocaoNaoExistir_DeveRetornarNull()
    {
        // Arrange
        PromocaoRepositoryMock.ConfigurarObterPorIdAsync(null);

        // Act
        var resultado = await ConsultaQuery.ObterPorIdAsync(999);

        // Assert
        resultado.Should().BeNull();
    }
}