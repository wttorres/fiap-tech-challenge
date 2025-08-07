using FluentAssertions;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechChallenge.GameStore.Application.Usuarios.Cadastrar;
using TechChallenge.GameStore.Domain.Jogos;
using TechChallenge.GameStore.Unit.Test.Application.Compras.Fakers;
using TechChallenge.GameStore.Unit.Test.Application.Compras.Fixtures;
using TechChallenge.GameStore.Unit.Test.Application.Usuarios.Fakers;
using TechChallenge.GameStore.Unit.Test.Infrastructure.Jogos.Fakers;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.Application.Compras
{
    public class ComprarJogoHandlerTest : ComprarJogoHandlerFixture
    {
        [Fact]
        public async Task Handle_QuandoUsuarioNaoExiste_DeveRetornarErro()
        {
            // Arrange
            var command = ComprarJogoCommandFaker.Valido();
            UsuarioRepositoryMock.ConfigurarParaObterPorId(null);

            // Act
            var result = await Handler.Handle(command, default);

            // Assert
            result.Sucesso.Should().BeFalse();
            result.Erro.Should().Be("Usuário não encontrado.");
        }

        [Fact]
        public async Task Handle_QuandoAlgumJogoNaoExiste_DeveRetornarErro()
        {
            // Arrange
            var command = ComprarJogoCommandFaker.Valido();
            var usuarioCommand = new CadastrarUsuarioCommand
            {
                Nome = "Usuário Teste",
                Email = "teste@email.com",
                Senha = "SenhaForte123"
            };

            var usuario = UsuarioFaker.ConverterParaUsuario(usuarioCommand);
            usuario.GetType().GetProperty("Id")?.SetValue(usuario, command.UsuarioId);

            UsuarioRepositoryMock.ConfigurarParaObterPorId(usuario);
            JogoRepositoryMock.ConfigurarObterAsync(command.JogosIds, new List<Jogo>()); // nenhum jogo retornado

            // Act
            var result = await Handler.Handle(command, default);

            // Assert
            result.Sucesso.Should().BeFalse();
            result.Erro.Should().Be("Um ou mais jogos não foram encontrados.");
        }

        [Fact]
        public async Task Handle_QuandoCompraValida_DeveRetornarSucesso()
        {
            // Arrange
            var command = ComprarJogoCommandFaker.Valido();
            var usuarioCommand = new CadastrarUsuarioCommand
            {
                Nome = "Usuário Teste",
                Email = "teste@email.com",
                Senha = "SenhaForte123"
            };

            var usuario = UsuarioFaker.ConverterParaUsuario(usuarioCommand);
            usuario.GetType().GetProperty("Id")?.SetValue(usuario, command.UsuarioId);

            var jogos = JogoFaker.Lista(command.JogosIds);

            UsuarioRepositoryMock.ConfigurarParaObterPorId(usuario);
            JogoRepositoryMock.ConfigurarObterAsync(command.JogosIds, jogos);
            PromocaoRepositoryMock.ConfigurarRetornarNenhuma();
            BibliotecaJogosRepositoryMock.ConfigurarNaoPossuiJogo();

            // Act
            var result = await Handler.Handle(command, default);

            // Assert
            result.Sucesso.Should().BeTrue();
            result.Valor.Should().Be("Compra realizada com sucesso.");
        }
    }
}
