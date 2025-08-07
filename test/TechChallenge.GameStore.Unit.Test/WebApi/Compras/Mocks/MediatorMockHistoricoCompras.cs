using Moq;
using System.Collections.Generic;
using System.Threading;
using MediatR;
using TechChallenge.GameStore.Application.Compras.Consultar;
using TechChallenge.GameStore.Domain._Shared;
using static TechChallenge.GameStore.Application.HistoricoCompras.HistoricoCompraResponse;

namespace TechChallenge.GameStore.Unit.Test.WebApi.HistoricoCompras.Mocks;

public class MediatorMockHistoricoCompras : Mock<IMediator>
{
    public void ConfigurarEnvio(ConsultaHistoricoComprasQuery query, Result<List<CompraDto>> resultado)
    {
        Setup(m => m.Send(
            It.Is<ConsultaHistoricoComprasQuery>(q => q.UsuarioId == query.UsuarioId),
            It.IsAny<CancellationToken>()
        )).ReturnsAsync(resultado);
    }

    public void GarantirEnvio(ConsultaHistoricoComprasQuery query)
    {
        Verify(m => m.Send(
            It.Is<ConsultaHistoricoComprasQuery>(q => q.UsuarioId == query.UsuarioId),
            It.IsAny<CancellationToken>()
        ), Times.Once);
    }
}
