using TechChallenge.GameStore.Unit.Test.WebApi.Notificacoes.Mocks;
using TechChallenge.GameStore.WebApi.Notificacoes.Consultar;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Notificacoes.Fixtures;

public class ConsultarNotificacoesControllerFixture
{
    protected ConsultaNotificacaoQueryMock ConsultaNotificacaoQueryMock { get; }
    protected ConsultarNotificacoesController Controller { get; }

    protected ConsultarNotificacoesControllerFixture()
    {
        ConsultaNotificacaoQueryMock = new ConsultaNotificacaoQueryMock();
        Controller = new ConsultarNotificacoesController(ConsultaNotificacaoQueryMock.Object);
    }
}