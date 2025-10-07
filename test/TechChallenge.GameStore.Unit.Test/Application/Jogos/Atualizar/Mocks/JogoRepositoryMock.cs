using Moq;
using TechChallenge.GameStore.Domain.Jogos;

namespace TechChallenge.GameStore.Unit.Test.Application.Jogos.Atualizar.Mocks;

public class JogoRepositoryMock : Mock<IJogoRepository>
{
    public void ConfigurarObterPorIdRetornando(Jogo jogo)
    {
        Setup(x => x.ObterPorIdAsync(It.IsAny<int>()))
            .ReturnsAsync(jogo);
    }

    public void GarantirObterPorIdChamado(int id)
    {
        Verify(x => x.ObterPorIdAsync(id), Times.Once);
    }

    public void GarantirAtualizarChamado(Jogo jogo)
    {
        Verify(x => x.AtualizarAsync(jogo), Times.Once);
    }

    public void GarantirAtualizarNaoChamado()
    {
        Verify(x => x.AtualizarAsync(It.IsAny<Jogo>()), Times.Never);
    }
}