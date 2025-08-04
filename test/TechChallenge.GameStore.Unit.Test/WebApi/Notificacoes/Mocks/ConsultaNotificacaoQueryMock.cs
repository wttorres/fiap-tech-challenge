using System.Collections.Generic;
using Moq;
using TechChallenge.GameStore.Application.Notificacoes.Consultar;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Notificacoes.Mocks;

public class ConsultaNotificacaoQueryMock : Mock<IConsultaNotificacaoQuery>
{
    public void ConfigurarObterTodasAsync(List<NotificacaoResponse> retorno)
    {
        Setup(x => x.ObterTodasAsync()).ReturnsAsync(retorno);
    }

    public void ConfigurarObterPorIdUsuarioAsync(int usuarioId, List<NotificacaoResponse> retorno)
    {
        Setup(x => x.ObterPorIdUsuarioAsync(usuarioId)).ReturnsAsync(retorno);
    }

    public void GarantirObterTodasAsyncChamado()
    {
        Verify(x => x.ObterTodasAsync(), Times.Once);
    }

    public void GarantirObterPorIdUsuarioAsyncChamado(int usuarioId)
    {
        Verify(x => x.ObterPorIdUsuarioAsync(usuarioId), Times.Once);
    }
}