using MediatR;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Compras;
using static TechChallenge.GameStore.Application.HistoricoCompras.HistoricoCompraResponse;

namespace TechChallenge.GameStore.Application.Compras.Consultar
{
    public class ConsultaHistoricoComprasHandler : IRequestHandler<ConsultaHistoricoComprasQuery, Result<List<CompraDto>>>
    {
        private readonly IHistoricoCompraRepository _repository;

        public ConsultaHistoricoComprasHandler(IHistoricoCompraRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<CompraDto>>> Handle(ConsultaHistoricoComprasQuery request, CancellationToken cancellationToken)
        {
            var compras = await _repository.ObterPorUsuarioIdAsync(request.UsuarioId);

            var resultado = compras
                .SelectMany(c => c.Itens.Select(i => new CompraDto
                {
                    DataCompra = c.DataCompra,
                    NomeJogo = i.Jogo.Nome,
                    ValorBase = i.Jogo.Preco,
                    ValorComDesconto = i.PrecoPago
                }))
                .ToList();

            return Result.Success(resultado);
        }
    }
}
