using TechChallenge.GameStore.Unit.Test.WebApi.Promocoes.Mocks;
using TechChallenge.GameStore.WebApi.Promocoes.Consultar;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Promocoes.Fixtures;

public abstract class ConsultarPromocaoControllerFixture
{
    protected ConsultarPromocaoController Controller { get; }
    protected ConsultaPromocaoQueryMock ConsultaPromocaoQueryMock { get; }

    protected ConsultarPromocaoControllerFixture()
    {
        ConsultaPromocaoQueryMock = new ConsultaPromocaoQueryMock();
        Controller = new ConsultarPromocaoController(ConsultaPromocaoQueryMock.Object);
    }
}