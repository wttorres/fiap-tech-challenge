using System.Collections.Generic;
using Moq;
using TechChallenge.GameStore.Domain.Notificacoes;

namespace TechChallenge.GameStore.Unit.Test.Application.Notificacoes.Mocks;

public class NotificacaoRepositoryMock : Mock<INotificacaoRepository>
{
    public void ConfigurarUsuariosNaoNotificados(List<int> usuarios)
    {
        Setup(r => r.ObterUsuariosNaoNotificadosAsync(
                It.IsAny<int>(), It.IsAny<List<int>>()))
            .ReturnsAsync(usuarios);
    }
    
    public void ConfigurarParaRetornarQueTodosJaForamNotificados()
    {
        Setup(r => r.ObterUsuariosNaoNotificadosAsync(
                It.IsAny<int>(), It.IsAny<List<int>>()))
            .ReturnsAsync([]);
    }

    public void GarantirSaveChangesChamado()
    {
        Verify(r => r.SaveChangesAsync(), Times.Once);
    }

    public void GarantirNotificacaoAdicionada()
    {
        Verify(r => r.Adicionar(It.IsAny<Notificacao>()), Times.AtLeastOnce);
    }
}