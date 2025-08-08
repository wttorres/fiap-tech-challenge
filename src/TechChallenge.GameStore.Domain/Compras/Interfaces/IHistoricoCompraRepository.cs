using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechChallenge.GameStore.Domain.Compras.Interfaces
{
    public interface IHistoricoCompraRepository
    {
        Task AdicionarAsync(HistoricoCompra compra);
        Task<List<HistoricoCompra>> ObterPorUsuarioIdAsync(int usuarioId);
    }
}
