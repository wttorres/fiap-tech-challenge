using System.Collections.Generic;
using Moq;
using TechChallenge.GameStore.Domain.Jogos;

namespace TechChallenge.GameStore.Unit.Test.Application.Jogos.Consultar.Mocks;

public class JogoRepositoryMock : Mock<IJogoRepository>
{
    public void ConfigurarObterTodos(List<Jogo> jogos)
    {
        Setup(x => x.ObterTodosAsync()).ReturnsAsync(jogos);
    }

    public void ConfigurarObterPorId(Jogo? jogo)
    {
        Setup(x => x.ObterPorIdAsync(It.IsAny<int>())).ReturnsAsync(jogo);
    }

    public void GarantirObterTodosChamado()
    {
        Verify(x => x.ObterTodosAsync(), Times.Once);
    }

    public void GarantirObterPorIdChamado(int id)
    {
        Verify(x => x.ObterPorIdAsync(id), Times.Once);
    }
}