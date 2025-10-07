using TechChallenge.GameStore.Application.Jogos.Atualizar;
using TechChallenge.GameStore.Unit.Test.Application.Jogos.Atualizar.Mocks;

namespace TechChallenge.GameStore.Unit.Test.Application.Jogos.Atualizar.Fixtures;

public abstract class AtualizarJogoHandlerFixture
{
    protected JogoRepositoryMock JogoRepositoryMock { get; }
    protected AtualizarJogoHandler Handler { get; }

    protected AtualizarJogoHandlerFixture()
    {
        JogoRepositoryMock = new JogoRepositoryMock();
        Handler = new AtualizarJogoHandler(JogoRepositoryMock.Object);
    }
}