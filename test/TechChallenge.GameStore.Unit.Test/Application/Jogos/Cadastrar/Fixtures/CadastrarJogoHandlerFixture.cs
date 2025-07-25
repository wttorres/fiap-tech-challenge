using TechChallenge.GameStore.Application.Jogos.Cadastrar;
using TechChallenge.GameStore.Unit.Test.Application.Jogos.Cadastrar.Mocks;

namespace TechChallenge.GameStore.Unit.Test.Application.Jogos.Cadastrar.Fixtures
{
    public class CadastrarJogoHandlerFixture
    {
        protected JogoRepositoryMock JogoRepositoryMock { get; private set; }
        protected CadastrarJogoHandler Handler { get; private set; }

        public CadastrarJogoHandlerFixture()
        {
            JogoRepositoryMock = new JogoRepositoryMock();
            Handler = new CadastrarJogoHandler(JogoRepositoryMock.Object);
        }
    }
}
