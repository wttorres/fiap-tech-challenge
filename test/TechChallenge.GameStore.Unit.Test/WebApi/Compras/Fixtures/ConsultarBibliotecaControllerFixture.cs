using TechChallenge.GameStore.Unit.Test.WebApi.Compras.Mocks;
using TechChallenge.GameStore.WebApi.Compras.Consultar;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Compras.Fixtures;

public abstract class ConsultarBibliotecaJogosControllerFixture
{
    protected ConsultarBibliotecaJogosController Controller { get; }
    protected MediatorMockBibliotecaJogos MediatorMock { get; }

    protected ConsultarBibliotecaJogosControllerFixture()
    {
        MediatorMock = new MediatorMockBibliotecaJogos();
        Controller = new ConsultarBibliotecaJogosController(MediatorMock.Object);
    }
}
