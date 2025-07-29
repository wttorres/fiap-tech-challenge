using MediatR;
using TechChallenge.GameStore.Domain._Shared;
using static TechChallenge.GameStore.Application.HistoricoCompras.CompraResponse;

namespace TechChallenge.GameStore.Application.Compras.Consultar
{
    public class ObterHistoricoComprasQuery : IRequest<Result<List<CompraDto>>>
    {
        public int UsuarioId { get; set; }

        public ObterHistoricoComprasQuery(int usuarioId)
        {
            UsuarioId = usuarioId;
        }
    }
}
