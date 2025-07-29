using MediatR;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Compras;
using static TechChallenge.GameStore.Application.HistoricoCompras.CompraResponse;

namespace TechChallenge.GameStore.Application.Compras.Consultar
{
    public class ObterHistoricoComprasHandler : IRequestHandler<ObterHistoricoComprasQuery, Result<List<CompraDto>>>
    {
        private readonly IHistoricoCompraRepository _repository;

        public ObterHistoricoComprasHandler(IHistoricoCompraRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<CompraDto>>> Handle(ObterHistoricoComprasQuery request, CancellationToken cancellationToken)
        {
            var compras = await _repository.ObterPorUsuarioIdAsync(request.UsuarioId);

            var resultado = compras
                .SelectMany(c => c.Itens.Select(i => new CompraDto
                {
                    DataCompra = c.DataCompra,
                    NomeJogo = i.Jogo.Nome,
                    PrecoPago = i.PrecoPago
                }))
                .ToList();

            return Result.Success(resultado);
        }
    }
}
