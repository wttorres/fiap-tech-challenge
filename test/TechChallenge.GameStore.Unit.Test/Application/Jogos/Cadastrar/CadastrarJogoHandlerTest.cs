using FluentAssertions;
using System.Threading.Tasks;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Jogos;
using TechChallenge.GameStore.Unit.Test.Application.Jogos.Cadastrar.Fakers;
using TechChallenge.GameStore.Unit.Test.Application.Jogos.Cadastrar.Fixtures;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.Application.Jogos.Cadastrar
{
    public class CadastrarJogoHandlerTest : CadastrarJogoHandlerFixture
    {
        [Fact]
        public async Task Handle_QuandoEmailJaCadastrado_DeveRetornarFalha()
        {
            // Arrange
            var command = CadastrarJogoCommandFaker.Valido();
            JogoRepositoryMock.ConfigurarParaRetornarJogoAoObterPorNome(JogoFaker.ConverterParaJogo(command));

            // Act
            var resultado = await Handler.Handle(command, default);

            // Assert
            resultado.Sucesso.Should().BeFalse();
            resultado.Erro.Should().Be("Jogo já cadastrado.");
            JogoRepositoryMock.GarantirQueNaoChamouAdicionar();
        }

        [Fact]
        public async Task Handle_QuandoUsuarioEhValido_DeveAdicionarEDevolverId()
        {
            // Arrange
            var command = CadastrarJogoCommandFaker.Valido();
            JogoRepositoryMock.ConfigurarParaRetornarJogoAoObterPorNome(null);

            var usuario = Jogo.Criar(command.Nome, command.Preco).Valor;
            JogoRepositoryMock.ConfigurarParaRetornarJogoAoAdicionar(Result.Success(usuario));

            // Act
            var resultado = await Handler.Handle(command, default);

            // Assert
            resultado.Sucesso.Should().BeTrue();
            resultado.Valor.Should().Be(usuario.Id.ToString());
            JogoRepositoryMock.GarantirChamadaAdicionar();
        }

        [Fact]
        public async Task Handle_QuandoJogoInvalido_DeveRetornarErro()
        {
            // Arrange
            var command = CadastrarJogoCommandFaker.ComNomeInvalido();
            JogoRepositoryMock.ConfigurarParaRetornarJogoAoObterPorNome(null);

            // Act
            var resultado = await Handler.Handle(command, default);

            // Assert
            resultado.Sucesso.Should().BeFalse();
            resultado.Erro.Should().Be("Nome é obrigatório.");
            JogoRepositoryMock.GarantirQueNaoChamouAdicionar();
        }

        [Fact]
        public async Task Handle_QuandoAdicionarRetornaErro_DevePropagarErro()
        {
            // Arrange
            var command = CadastrarJogoCommandFaker.Valido();
            JogoRepositoryMock.ConfigurarParaRetornarJogoAoObterPorNome(null);

            var usuario = Jogo.Criar(command.Nome, command.Preco).Valor;
            JogoRepositoryMock.ConfigurarParaRetornarJogoAoAdicionar(Result.Failure<Jogo>("Erro ao adicionar"));

            // Act
            var resultado = await Handler.Handle(command, default);

            // Assert
            resultado.Sucesso.Should().BeFalse();
            resultado.Erro.Should().Be("Erro ao adicionar");
        }
    }
}
