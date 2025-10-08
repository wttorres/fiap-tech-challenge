using TechChallenge.GameStore.Unit.Test.WebApi.Jogos.Mocks;
using TechChallenge.GameStore.WebApi.Jogos.Atualizar;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Jogos.Fixtures;

public class AtualizarJogoControllerFixture
{
    protected MediatorMockJogos MediatorMock { get; private set; }
    protected AtualizarJogoController Controller { get; private set; }

    protected AtualizarJogoControllerFixture()
    {
        MediatorMock = new MediatorMockJogos();
        Controller = new AtualizarJogoController(MediatorMock.Object);
    }
}