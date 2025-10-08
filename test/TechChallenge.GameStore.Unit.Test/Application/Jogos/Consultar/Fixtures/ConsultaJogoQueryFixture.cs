using TechChallenge.GameStore.Application.Jogos.Consultar;
using TechChallenge.GameStore.Unit.Test.Application.Jogos.Consultar.Mocks;

namespace TechChallenge.GameStore.Unit.Test.Application.Jogos.Consultar.Fixtures;

public abstract class ConsultaJogoQueryFixture
{
    protected JogoRepositoryMock JogoRepositoryMock { get; }
    protected ConsultaJogoQuery Consulta { get; }

    protected ConsultaJogoQueryFixture()
    {
        JogoRepositoryMock = new JogoRepositoryMock();
        Consulta = new ConsultaJogoQuery(JogoRepositoryMock.Object);
    }
}