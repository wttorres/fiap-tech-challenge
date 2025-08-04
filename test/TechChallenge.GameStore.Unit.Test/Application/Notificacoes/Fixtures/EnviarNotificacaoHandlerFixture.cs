using TechChallenge.GameStore.Application.Notificacoes.Enviar;
using TechChallenge.GameStore.Unit.Test.Application.Notificacoes.Mocks;

namespace TechChallenge.GameStore.Unit.Test.Application.Notificacoes.Fixtures;

public abstract class EnviarNotificacaoHandlerFixture
{
    protected PromocaoRepositoryMock PromocaoRepositoryMock { get; }
    protected UsuarioRepositoryMock UsuarioRepositoryMock { get; }
    protected NotificacaoRepositoryMock NotificacaoRepositoryMock { get; }
    protected EmailSenderMock EmailSenderMock { get; }

    protected EnviarNotificacaoHandler Handler { get; }

    protected EnviarNotificacaoHandlerFixture()
    {
        PromocaoRepositoryMock = new();
        UsuarioRepositoryMock = new();
        NotificacaoRepositoryMock = new();
        EmailSenderMock = new();

        Handler = new EnviarNotificacaoHandler(
            PromocaoRepositoryMock.Object,
            UsuarioRepositoryMock.Object,
            NotificacaoRepositoryMock.Object,
            EmailSenderMock.Object);
    }
}