using TechChallenge.GameStore.Application.Compras.Consultar;
using TechChallenge.GameStore.Unit.Test.Application.Compras.Mocks;

namespace TechChallenge.GameStore.Unit.Test.Application.Compras.Fixtures;

public abstract class ConsultaHistoricoCompraHandlerFixture
{
    protected HistoricoCompraRepositoryMock HistoricoCompraRepositoryMock { get; }
    protected ConsultaHistoricoComprasHandler Handler { get; }

    protected ConsultaHistoricoCompraHandlerFixture()
    {
        HistoricoCompraRepositoryMock = new HistoricoCompraRepositoryMock();
        Handler = new ConsultaHistoricoComprasHandler(HistoricoCompraRepositoryMock.Object);
    }
}
