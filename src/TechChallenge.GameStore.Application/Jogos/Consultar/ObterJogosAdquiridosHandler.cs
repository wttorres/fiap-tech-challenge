using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Compras;

namespace TechChallenge.GameStore.Application.Jogos.Consultar
{
    public class ObterJogosAdquiridosHandler
    {
        private readonly IHistoricoCompraRepository _historicoRepository;

        public ObterJogosAdquiridosHandler(IHistoricoCompraRepository historicoRepository)
        {
            _historicoRepository = historicoRepository;
        }

        public async Task<Result<List<JogoAdquiridoResponse>>> Handle(ObterJogosAdquiridosQuery request, CancellationToken cancellationToken)
        {
            var compras = await _historicoRepository.ObterPorUsuarioIdAsync(request.UsuarioId);

            var jogos = compras
                .SelectMany(c => c.Itens.Select(i => new JogoAdquiridoResponse
                {
                    Nome = i.Jogo.Nome,
                    PrecoPago = i.PrecoPago,
                    DataCompra = c.DataCompra
                }))
                .ToList();

            return Result.Success(jogos);
        }
    }
}
