using System.Collections.Generic;
using Moq;
using TechChallenge.GameStore.Domain.Jogos;
using TechChallenge.GameStore.Domain.Promocoes;

namespace TechChallenge.GameStore.Unit.Test.Application.Promocoes.Mocks;

public class PromocaoRepositoryMock : Mock<IPromocaoRepository>
{
    public void ConfigurarExisteAsync(string nome, bool existe)
    {
        Setup(p => p.ExisteAsync(nome)).ReturnsAsync(existe);
    }
    
    public void JogoNaoPossuiPromocaoCadastrada()
    {
        Setup(p => p.ObterPorJogosIdsAsync(It.IsAny<List<int>>())).ReturnsAsync([]);
    }
    
    public void JogoPossuiPromocaoCadastrada()
    {
        Setup(p => p.ObterPorJogosIdsAsync(It.IsAny<List<int>>()))
            .ReturnsAsync([new PromocaoJogo { Jogo = new Jogo()}]);
    }
    
    public void GarantirAdicao()
    {
        Verify(p => p.AdicionarAsync(It.IsAny<Promocao>()), Times.Once);
    }
}