using Moq;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Jogos;

namespace TechChallenge.GameStore.Unit.Test.Application.Jogos.Cadastrar.Mocks
{
    public class JogoRepositoryMock : Mock<IJogoRepository>
    {
        public void ConfigurarParaRetornarJogoAoObterPorNome(Jogo jogo)
        {
            Setup(x => x.ObterPorNome(It.IsAny<string>()))
                .ReturnsAsync(jogo);
        }

        public void ConfigurarParaRetornarJogoAoAdicionar(Result<Jogo> resultado)
        {
            Setup(x => x.AdicionarAsync(It.IsAny<Jogo>()))
                .ReturnsAsync(resultado);
        }

        public void GarantirChamadaAdicionar()
        {
            Verify(x => x.AdicionarAsync(It.IsAny<Jogo>()), Times.Once);
        }

        public void GarantirQueNaoChamouAdicionar()
        {
            Verify(x => x.AdicionarAsync(It.IsAny<Jogo>()), Times.Never);
        }
    }
}
