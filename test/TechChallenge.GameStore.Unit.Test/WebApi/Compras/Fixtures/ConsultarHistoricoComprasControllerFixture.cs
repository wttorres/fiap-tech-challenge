using TechChallenge.GameStore.Unit.Test.WebApi.Compras.Mocks;
using TechChallenge.GameStore.Unit.Test.WebApi.HistoricoCompras.Mocks;
using TechChallenge.GameStore.WebApi.Compras.Consultar;

namespace TechChallenge.GameStore.Unit.Test.WebApi.HistoricoCompras.Fixtures;

public abstract class ConsultarHistoricoComprasControllerFixture
{
    protected ObterHistoricoComprasController Controller { get; }
    protected MediatorMockHistoricoCompras MediatorMock { get; }

    protected ConsultarHistoricoComprasControllerFixture()
    {
        MediatorMock = new MediatorMockHistoricoCompras();
        Controller = new ObterHistoricoComprasController(MediatorMock.Object);
    }
}
