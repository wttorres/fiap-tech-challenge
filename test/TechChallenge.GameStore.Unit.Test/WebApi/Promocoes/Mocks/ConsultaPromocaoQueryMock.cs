using System.Collections.Generic;
using Moq;
using TechChallenge.GameStore.Application.Promocoes.Consultar;

namespace TechChallenge.GameStore.Unit.Test.WebApi.Promocoes.Mocks;

public class ConsultaPromocaoQueryMock : Mock<IConsultaPromocaoQuery>
{
    public void ConfigurarObterTodasAsync(List<PromocaoResponse> resultado)
    {
        Setup(x => x.ObterTodasAsync()).ReturnsAsync(resultado);
    }

    public void ConfigurarObterPorIdAsync(PromocaoResponse? resultado)
    {
        Setup(x => x.ObterPorIdAsync(It.IsAny<int>())).ReturnsAsync(resultado);
    }
}