using System.Collections.Generic;
using Moq;
using TechChallenge.GameStore.Domain.Promocoes;

namespace TechChallenge.GameStore.Unit.Test.Application.Notificacoes.Mocks;

public class PromocaoRepositoryMock : Mock<IPromocaoRepository>
{
    public void ConfigurarPromocoes(List<Promocao> promocoes)
    {
        Setup(r => r.ObterPromocoesAtivasComJogosAsync())
            .ReturnsAsync(promocoes);
    }
}