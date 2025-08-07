using TechChallenge.GameStore.Application.Compras.Consultar;
using TechChallenge.GameStore.Unit.Test.Application.Compras.Mocks;

namespace TechChallenge.GameStore.Unit.Test.Application.Compras.Fixtures;

public abstract class ConsultaBibliotecaJogosHandlerFixture
{
    protected BibliotecaJogosRepositoryMock BibliotecaJogosRepositoryMock { get; }
    protected ConsultaBibliotecaJogosHandler Handler { get; }

    protected ConsultaBibliotecaJogosHandlerFixture()
    {
        BibliotecaJogosRepositoryMock = new BibliotecaJogosRepositoryMock();
        Handler = new ConsultaBibliotecaJogosHandler(BibliotecaJogosRepositoryMock.Object);
    }
}
