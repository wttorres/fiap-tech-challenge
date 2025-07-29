using System.Linq;
using FluentAssertions;
using TechChallenge.GameStore.Domain.Promocoes;
using TechChallenge.GameStore.Unit.Test.Domain.Promocoes.Fakers;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.Domain.Promocoes;

public class PromocaoTest
{
    [Fact]
    public void Criar_ComDadosValidos_DeveRetornarPromocaoValida()
    {
        // Arrange
        var (nome, descricao, desconto, inicio, fim) = PromocaoFaker.DadosValidos();

        // Act
        var result = Promocao.Criar(nome, descricao, desconto, inicio, fim);

        // Assert
        result.Sucesso.Should().BeTrue();
        result.Valor.Nome.Should().Be(nome);
        result.Valor.Descricao.Should().Be(descricao);
        result.Valor.DescontoPercentual.Should().Be(desconto);
        result.Valor.DataInicio.Should().Be(inicio);
        result.Valor.DataFim.Should().Be(fim);
    }

    [Fact]
    public void Criar_QuandoNomeVazio_DeveRetornarErro()
    {
        // Arrange
        var (_, descricao, desconto, inicio, fim) = PromocaoFaker.DadosValidos();

        // Act
        var result = Promocao.Criar("", descricao, desconto, inicio, fim);

        // Assert
        result.Sucesso.Should().BeFalse();
        result.Erro.Should().Be("Nome da promoção é obrigatório.");
    }

    [Theory]
    [InlineData(0)]
    [InlineData(101)]
    [InlineData(-5)]
    public void Criar_QuandoDescontoInvalido_DeveRetornarErro(decimal desconto)
    {
        // Arrange
        var (nome, descricao, _, inicio, fim) = PromocaoFaker.DadosValidos();

        // Act
        var result = Promocao.Criar(nome, descricao, desconto, inicio, fim);

        // Assert
        result.Sucesso.Should().BeFalse();
        result.Erro.Should().Be("Desconto percentual deve estar entre 1 e 100.");
    }

    [Fact]
    public void Criar_QuandoDataFimMenorOuIgualADataInicio_DeveRetornarErro()
    {
        // Arrange
        var (nome, descricao, desconto, inicio, _) = PromocaoFaker.DadosValidos();
        var fim = inicio;

        // Act
        var result = Promocao.Criar(nome, descricao, desconto, inicio, fim);

        // Assert
        result.Sucesso.Should().BeFalse();
        result.Erro.Should().Be("Data de fim deve ser após a data de início.");
    }

    [Fact]
    public void AdicionarJogos_ComIdsValidos_DeveAdicionarJogos()
    {
        // Arrange
        var (nome, descricao, desconto, inicio, fim) = PromocaoFaker.DadosValidos();
        var result = Promocao.Criar(nome, descricao, desconto, inicio, fim);
        var promocao = result.Valor;
        var jogosIds = PromocaoFaker.JogosIdsValidos();

        // Act
        promocao.AdicionarJogos(jogosIds);

        // Assert
        promocao.Jogos.Should().HaveCount(jogosIds.Count());
        promocao.Jogos.Select(j => j.JogoId).Should().BeEquivalentTo(jogosIds);
    }

    [Fact]
    public void Atualizar_ComDadosValidos_DeveAtualizarAtributos()
    {
        // Arrange
        var result = PromocaoFaker.CriarValida();
        var promocao = result.Valor;

        var (novoNome, novaDescricao, novoDesconto, novoInicio, novoFim) = PromocaoFaker.DadosValidos();

        // Act
        promocao.Atualizar(novoNome, novaDescricao, novoDesconto, novoInicio, novoFim);

        // Assert
        promocao.Nome.Should().Be(novoNome);
        promocao.Descricao.Should().Be(novaDescricao);
        promocao.DescontoPercentual.Should().Be(novoDesconto);
        promocao.DataInicio.Should().Be(novoInicio);
        promocao.DataFim.Should().Be(novoFim);
    }

    [Fact]
    public void AtualizarJogos_ComNovosIds_DeveSubstituirJogos()
    {
        // Arrange
        var result = PromocaoFaker.CriarValida();
        var promocao = result.Valor;

        var jogosAntigos = PromocaoFaker.JogosIdsValidos();
        promocao.AdicionarJogos(jogosAntigos);

        var novosIds = PromocaoFaker.JogosIdsAlternativos();

        // Act
        promocao.AtualizarJogos(novosIds);

        // Assert
        promocao.Jogos.Should().HaveCount(novosIds.Count());
        promocao.Jogos.Select(j => j.JogoId).Should().BeEquivalentTo(novosIds);
    }
}
