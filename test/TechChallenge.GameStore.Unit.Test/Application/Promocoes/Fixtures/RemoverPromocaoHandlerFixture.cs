using TechChallenge.GameStore.Application.Promocoes.Remover;
using TechChallenge.GameStore.Unit.Test.Application.Promocoes.Mocks;

namespace TechChallenge.GameStore.Unit.Test.Application.Promocoes.Fixtures;

public class RemoverPromocaoHandlerFixture
{
    protected PromocaoRepositoryMock PromocaoRepositoryMock { get; }
    protected RemoverPromocaoHandler Handler { get; }

    public RemoverPromocaoHandlerFixture()
    {
        PromocaoRepositoryMock = new PromocaoRepositoryMock();
        Handler = new RemoverPromocaoHandler(PromocaoRepositoryMock.Object);
    }
}