using TechChallenge.GameStore.Unit.Test.WebApi.Promocoes.Mocks;
using TechChallenge.GameStore.WebApi.Promocoes.Cadastrar;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Promocoes.Fixtures;

public class CadastrarPromocaoControllerFixture
{
    protected MediatorMock MediatorMock { get; private set; }
    protected CadastrarPromocaoController Controller { get; private set; }

    public CadastrarPromocaoControllerFixture()
    {
        MediatorMock = new MediatorMock();
        Controller = new CadastrarPromocaoController(MediatorMock.Object);
    }
}