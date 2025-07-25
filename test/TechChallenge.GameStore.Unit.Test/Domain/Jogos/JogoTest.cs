using FluentAssertions;
using TechChallenge.GameStore.Domain.Jogos;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.Domain.Jogos;

public class JogoTest
{
    [Fact]
    public void Criar_QuandoDadosValidos_DeveRetornarSucesso()
    {
        // Arrange
        var nome = "The Witcher 3";
        var preco = 99.90m;

        // Act
        var resultado = Jogo.Criar(nome, preco);

        // Assert
        resultado.Sucesso.Should().BeTrue();
        resultado.Valor.Should().NotBeNull();
        resultado.Valor!.Nome.Should().Be(nome);
        resultado.Valor.Preco.Should().Be(preco);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Criar_QuandoNomeInvalido_DeveRetornarErro(string nomeInvalido)
    {
        // Arrange
        var preco = 59.90m;

        // Act
        var resultado = Jogo.Criar(nomeInvalido, preco);

        // Assert
        resultado.Sucesso.Should().BeFalse();
        resultado.Erro.Should().Be("Nome é obrigatório.");
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-99.99)]
    public void Criar_QuandoPrecoInvalido_DeveRetornarErro(decimal precoInvalido)
    {
        // Arrange
        var nome = "FIFA 22";

        // Act
        var resultado = Jogo.Criar(nome, precoInvalido);

        // Assert
        resultado.Sucesso.Should().BeFalse();
        resultado.Erro.Should().Be("Preço inválido.");
    }
}
