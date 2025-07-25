using TechChallenge.GameStore.Unit.Test.WebApi.Jogos.Mocks;
using TechChallenge.GameStore.WebApi.Jogos.Cadastrar;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Jogos.Fixtures;

public class CadastrarJogoControllerFixture
{
    protected MediatorMockJogos MediatorMock { get; private set; }
    protected CadastrarJogoController Controller { get; private set; }

    public CadastrarJogoControllerFixture()
    {
        MediatorMock = new MediatorMockJogos();
        Controller = new CadastrarJogoController(MediatorMock.Object);
    }
}
