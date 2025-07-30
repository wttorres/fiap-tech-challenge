using MediatR;
using TechChallenge.GameStore.Domain._Shared;
using static TechChallenge.GameStore.Application.HistoricoCompras.HistoricoCompraResponse;

namespace TechChallenge.GameStore.Application.Compras.Consultar
{
    public class ConsultaHistoricoComprasQuery : IRequest<Result<List<CompraDto>>>
    {
        public int UsuarioId { get; set; }

        public ConsultaHistoricoComprasQuery(int usuarioId)
        {
            UsuarioId = usuarioId;
        }
    }
}
