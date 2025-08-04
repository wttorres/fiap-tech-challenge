using TechChallenge.GameStore.Application.Notificacoes.Consultar;
using TechChallenge.GameStore.Unit.Test.Application.Notificacoes.Mocks;

namespace TechChallenge.GameStore.Unit.Test.Application.Notificacoes.Fixtures;

public class ConsultaNotificacaoQueryFixture
{
    protected NotificacaoRepositoryMock NotificacaoRepositoryMock { get; }
    protected ConsultaNotificacaoQuery ConsultaQuery { get; }

    protected ConsultaNotificacaoQueryFixture()
    {
        NotificacaoRepositoryMock = new NotificacaoRepositoryMock();
        ConsultaQuery = new ConsultaNotificacaoQuery(NotificacaoRepositoryMock.Object);
    }
}