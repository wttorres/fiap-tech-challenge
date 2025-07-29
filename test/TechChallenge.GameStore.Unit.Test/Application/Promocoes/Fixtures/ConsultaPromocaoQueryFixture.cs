using TechChallenge.GameStore.Application.Promocoes.Consultar;
using TechChallenge.GameStore.Unit.Test.Application.Promocoes.Mocks;

namespace TechChallenge.GameStore.Unit.Test.Application.Promocoes.Fixtures;

public abstract class ConsultaPromocaoQueryFixture
{
    protected PromocaoRepositoryMock PromocaoRepositoryMock { get; }
    protected ConsultaPromocaoQuery ConsultaQuery { get; }

    protected ConsultaPromocaoQueryFixture()
    {
        PromocaoRepositoryMock = new PromocaoRepositoryMock();
        ConsultaQuery = new ConsultaPromocaoQuery(PromocaoRepositoryMock.Object);
    }
}