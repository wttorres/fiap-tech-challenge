using TechChallenge.GameStore.Unit.Test.WebApi.Promocoes.Mocks;
using TechChallenge.GameStore.WebApi.Promocoes.Remover;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Promocoes.Fixtures
{
    public class RemoverPromocaoControllerFixture
    {
        protected MediatorMock MediatorMock { get; }
        protected RemoverPromocaoController Controller { get; }

        public RemoverPromocaoControllerFixture()
        {
            MediatorMock = new MediatorMock();
            Controller = new RemoverPromocaoController(MediatorMock.Object);
        }
    }
}