using TechChallenge.GameStore.Application.Promocoes.Atualizar;
using TechChallenge.GameStore.Unit.Test.Application.Promocoes.Mocks;

namespace TechChallenge.GameStore.Unit.Test.Application.Promocoes.Fixtures;

public class AtualizarPromocaoHandlerFixture
{
    protected JogoRepositoryMock JogoRepositoryMock { get; private set; }
    protected PromocaoRepositoryMock PromocaoRepositoryMock { get; private set; }
    protected AtualizarPromocaoHandler Handler { get; private set; }

    protected AtualizarPromocaoHandlerFixture()
    {
        JogoRepositoryMock     = new JogoRepositoryMock();
        PromocaoRepositoryMock = new PromocaoRepositoryMock();

        Handler = new AtualizarPromocaoHandler(
            JogoRepositoryMock.Object,
            PromocaoRepositoryMock.Object
        );
    }
}