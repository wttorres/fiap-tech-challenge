using TechChallenge.GameStore.Unit.Test.WebApi.Compras.Mocks;
using TechChallenge.GameStore.WebApi.Compras.Comprar;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Compras.Fixtures;

public class ComprarJogoControllerFixture
{
    protected MediatorMockCompras MediatorMock { get; private set; }
    protected ComprarJogoController Controller { get; private set; }

    public ComprarJogoControllerFixture()
    {
        MediatorMock = new MediatorMockCompras();
        Controller = new ComprarJogoController(MediatorMock.Object);
    }
}
