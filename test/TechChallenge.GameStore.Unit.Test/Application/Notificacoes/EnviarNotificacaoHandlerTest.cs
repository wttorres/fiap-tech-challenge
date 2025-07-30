using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using TechChallenge.GameStore.Application.Notificacoes.Enviar;
using TechChallenge.GameStore.Domain.Notificacoes;
using TechChallenge.GameStore.Domain.Promocoes;
using TechChallenge.GameStore.Domain.Usuarios;
using TechChallenge.GameStore.Unit.Test.Application.Notificacoes.Fakers;
using TechChallenge.GameStore.Unit.Test.Application.Notificacoes.Fixtures;
using Xunit;

namespace TechChallenge.GameStore.Unit.Test.Application.Notificacoes;

public class EnviarNotificacaoHandlerTest : EnviarNotificacaoHandlerFixture
{
    [Fact]
    public async Task Handle_QuandoUsuariosNaoForamNotificados_DeveEnviarEmails()
    {
        // Arrange
        var usuarios = UsuarioFaker.ListaValida(3);
        var promocoes = PromocaoFaker.ComUmJogo();
        var usuariosNaoNotificados = usuarios.Select(u => u.Id).ToList();

        UsuarioRepositoryMock.ConfigurarUsuarios(usuarios);
        PromocaoRepositoryMock.ConfigurarPromocoes(promocoes);
        NotificacaoRepositoryMock.ConfigurarUsuariosNaoNotificados(usuariosNaoNotificados);
        EmailSenderMock.ConfigurarEnvioEmail();

        var command = new EnviarNotificacaoCommand();

        // Act
        await Handler.Handle(command, CancellationToken.None);

        // Assert
        NotificacaoRepositoryMock.GarantirNotificacaoAdicionada();
        NotificacaoRepositoryMock.GarantirSaveChangesChamado();
        EmailSenderMock.GarantirEnvioEmail(3);
    }

    [Fact]
    public async Task Handle_QuandoNaoHaUsuariosParaNotificar_NaoDeveEnviarEmails()
    {
        // Arrange
        var usuarios  = UsuarioFaker.ListaValida(2);
        var promocoes = PromocaoFaker.ComJogos(1);

        UsuarioRepositoryMock.ConfigurarUsuarios(usuarios);
        PromocaoRepositoryMock.ConfigurarPromocoes(promocoes);
        NotificacaoRepositoryMock.ConfigurarParaRetornarQueTodosJaForamNotificados();

        var command = new EnviarNotificacaoCommand();

        // Act
        await Handler.Handle(command, CancellationToken.None);

        // Assert
        EmailSenderMock.GarantirEnvioEmail(0);
    }
    
    [Fact]
    public async Task Handle_QuandoNaoHaPromocoesAtivas_NaoDeveEnviarEmails()
    {
        // Arrange
        var usuarios = UsuarioFaker.ListaValida(3);
        var promocoes = new List<Promocao>(); 

        UsuarioRepositoryMock.ConfigurarUsuarios(usuarios);
        PromocaoRepositoryMock.ConfigurarPromocoes(promocoes);

        var command = new EnviarNotificacaoCommand();

        // Act
        await Handler.Handle(command, CancellationToken.None);

        // Assert
        EmailSenderMock.GarantirEnvioEmail(0);
        NotificacaoRepositoryMock.Verify(r => r.Adicionar(It.IsAny<Notificacao>()), Times.Never);
        NotificacaoRepositoryMock.Verify(r => r.SaveChangesAsync(), Times.Never);
    }
    
    [Fact]
    public async Task Handle_QuandoNaoHaUsuariosParaReceberNotificacao_NaoDeveConsultarPromocoes()
    {
        // Arrange
        UsuarioRepositoryMock.ConfigurarUsuarios(new List<Usuario>()); 
        PromocaoRepositoryMock.ConfigurarPromocoes(new List<Promocao>()); 

        var command = new EnviarNotificacaoCommand();

        // Act
        await Handler.Handle(command, CancellationToken.None);

        // Assert
        PromocaoRepositoryMock.Verify(r => r.ObterPromocoesAtivasComJogosAsync(), Times.Never);
        EmailSenderMock.GarantirEnvioEmail(0);
        NotificacaoRepositoryMock.Verify(r => r.Adicionar(It.IsAny<Notificacao>()), Times.Never);
    }

    [Fact]
    public async Task Handle_QuandoUmaPromocaoPossuiMultiplosJogos_DeveCriarNotificacoesParaCadaJogo()
    {
        // Arrange
        var usuarios = UsuarioFaker.ListaValida(1);
        var promocao = PromocaoFaker.ComJogos(1).First();
        promocao.Jogos.AddRange(PromocaoFaker.ComJogos(2).First().Jogos);

        UsuarioRepositoryMock.ConfigurarUsuarios(usuarios);
        PromocaoRepositoryMock.ConfigurarPromocoes(new List<Promocao> { promocao });
        NotificacaoRepositoryMock.ConfigurarUsuariosNaoNotificados([usuarios[0].Id]);

        EmailSenderMock.ConfigurarEnvioEmail();

        var command = new EnviarNotificacaoCommand();

        // Act
        await Handler.Handle(command, CancellationToken.None);

        // Assert
        EmailSenderMock.GarantirEnvioEmail(promocao.Jogos.Count);
        NotificacaoRepositoryMock.GarantirNotificacaoAdicionada();
        NotificacaoRepositoryMock.GarantirSaveChangesChamado();
    }
}