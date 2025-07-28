using System.Collections.Generic;
using Moq;
using TechChallenge.GameStore.Domain._Shared;
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
    
    public void ConfigurarObterPorId(Promocao? resultado)
    {
        Setup(x => x.ObterPorIdAsync(It.IsAny<int>())).ReturnsAsync(resultado);
    }

    public void ConfigurarExcluir(Promocao promocao, Result<string> resultado)
    {
        Setup(x => x.ExcluirAsync(promocao)).ReturnsAsync(resultado);
    }

    public void GarantirConsultaPorId(int id)
    {
        Verify(x => x.ObterPorIdAsync(id), Times.Once);
    }

    public void GarantirExclusao(Promocao promocao)
    {
        Verify(x => x.ExcluirAsync(promocao), Times.Once);
    }
}