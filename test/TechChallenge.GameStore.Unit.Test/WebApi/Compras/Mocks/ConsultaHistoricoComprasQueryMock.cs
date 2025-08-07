using System.Collections.Generic;
using Moq;
using System.Threading;
using MediatR;
using TechChallenge.GameStore.Application.Compras.Consultar;
using TechChallenge.GameStore.Domain._Shared;
using static TechChallenge.GameStore.Application.HistoricoCompras.HistoricoCompraResponse;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Compras.Mocks;

public class ConsultaHistoricoComprasQueryMock : Mock<IRequestHandler<ConsultaHistoricoComprasQuery, Result<List<CompraDto>>>>
{
    public void ConfigurarHandle(ConsultaHistoricoComprasQuery query, Result<List<CompraDto>> resultado)
    {
        Setup(x => x.Handle(query, It.IsAny<CancellationToken>()))
            .ReturnsAsync(resultado);
    }

    public void GarantirHandleChamado(ConsultaHistoricoComprasQuery query)
    {
        Verify(x => x.Handle(query, It.IsAny<CancellationToken>()), Times.Once);
    }
}
