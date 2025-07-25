using System.Collections.Generic;
using Moq;
using TechChallenge.GameStore.Domain.Jogos;

namespace TechChallenge.GameStore.Unit.Test.Application.Promocoes.Mocks;

public class JogoRepositoryMock : Mock<IJogoRepository>
{
    public void ConfigurarObterAsync(List<int> ids, List<Jogo> jogos)
    {
        Setup(j => j.ObterAsync(ids)).ReturnsAsync(jogos);
    }
}