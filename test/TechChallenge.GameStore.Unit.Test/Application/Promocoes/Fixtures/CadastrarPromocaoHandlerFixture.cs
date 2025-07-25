using TechChallenge.GameStore.Application.Promocoes.Cadastar;
using TechChallenge.GameStore.Unit.Test.Application.Promocoes.Mocks;

namespace TechChallenge.GameStore.Unit.Test.Application.Promocoes.Fixtures;

public class CadastrarPromocaoHandlerFixture
{
    protected JogoRepositoryMock JogoRepositoryMock { get; private set; }
    protected PromocaoRepositoryMock PromocaoRepositoryMock { get; private set; }
    protected CadastrarPromocaoHandler Handler { get; private set; }

    public CadastrarPromocaoHandlerFixture()
    {
        JogoRepositoryMock = new JogoRepositoryMock();
        PromocaoRepositoryMock = new PromocaoRepositoryMock();

        Handler = new CadastrarPromocaoHandler(
            JogoRepositoryMock.Object,
            PromocaoRepositoryMock.Object
        );
    }
}