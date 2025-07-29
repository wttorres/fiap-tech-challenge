using TechChallenge.GameStore.Unit.Test.WebApi.Promocoes.Mocks;
using TechChallenge.GameStore.WebApi.Promocoes.Atualizar;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Promocoes.Fixtures;

public class AtualizarPromocaoControllerFixture
{
    protected MediatorMock MediatorMock { get; private set; }
    protected AtualizarPromocaoController Controller { get; private set; }

    protected AtualizarPromocaoControllerFixture()
    {
        MediatorMock = new MediatorMock();
        Controller   = new AtualizarPromocaoController(MediatorMock.Object);
    }
}