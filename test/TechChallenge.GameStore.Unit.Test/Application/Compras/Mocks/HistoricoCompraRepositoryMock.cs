using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechChallenge.GameStore.Domain.Compras;

namespace TechChallenge.GameStore.Unit.Test.Application.Compras.Mocks
{
    public class HistoricoCompraRepositoryMock : Mock<IHistoricoCompraRepository>
    {
        public void ConfigurarAdicionarAsync()
        {
            Setup(r => r.AdicionarAsync(It.IsAny<HistoricoCompra>()))
                .Returns(Task.CompletedTask);
        }

        public void ConfigurarObterPorUsuarioIdAsync(int usuarioId, List<HistoricoCompra> compras)
        {
            Setup(r => r.ObterPorUsuarioIdAsync(usuarioId))
                .ReturnsAsync(compras);
        }
    }
}
