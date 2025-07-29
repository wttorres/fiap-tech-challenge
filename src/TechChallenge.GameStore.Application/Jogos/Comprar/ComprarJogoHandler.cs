using MediatR;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Usuarios;
using TechChallenge.GameStore.Domain.Jogos;
using TechChallenge.GameStore.Domain.Promocoes;
using TechChallenge.GameStore.Domain.Compras;

namespace TechChallenge.GameStore.Application.Jogos.Comprar
{
    public class ComprarJogoHandler : IRequestHandler<ComprarJogoCommand, Result<string>>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IJogoRepository _jogoRepository;
        private readonly IPromocaoRepository _promocaoRepository;
        private readonly IHistoricoCompraRepository _historicoRepository;
        private readonly IBibliotecaJogosRepository _bibliotecaRepository;

        public ComprarJogoHandler(
            IUsuarioRepository usuarioRepository,
            IJogoRepository jogoRepository,
            IPromocaoRepository promocaoRepository,
            IHistoricoCompraRepository historicoRepository,
            IBibliotecaJogosRepository bibliotecaRepository)
        {
            _usuarioRepository = usuarioRepository;
            _jogoRepository = jogoRepository;
            _promocaoRepository = promocaoRepository;
            _historicoRepository = historicoRepository;
            _bibliotecaRepository = bibliotecaRepository;
        }

        public async Task<Result<string>> Handle(ComprarJogoCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.ObterPorIdAsync(request.UsuarioId);

            if (usuario is null)
                return Result.Failure<string>("Usuário não encontrado.");

            var jogos = await _jogoRepository.ObterAsync(request.JogosIds);

            if (jogos.Count != request.JogosIds.Count)
                return Result.Failure<string>("Um ou mais jogos não foram encontrados.");

            return await RealizarCompraAsync(usuario.Id, jogos);
        }

        private async Task<Result<string>> RealizarCompraAsync(int usuarioId, List<Jogo> jogos)
        {
            var itens = new List<ItemCompra>();

            var promocoes = await _promocaoRepository.ObterPorJogosIdsAsync(jogos.Select(j => j.Id).ToList());

            foreach (var jogo in jogos)
            {
                var promocao = promocoes
                    .FirstOrDefault(p => p.JogoId == jogo.Id &&
                                         p.Promocao.DataInicio <= DateTime.UtcNow &&
                                         p.Promocao.DataFim >= DateTime.UtcNow);

                var desconto = promocao?.Promocao?.DescontoPercentual ?? 0m;
                var precoFinal = jogo.Preco - (jogo.Preco * desconto);

                itens.Add(new ItemCompra
                {
                    JogoId = jogo.Id,
                    PrecoPago = precoFinal
                });

                var jaPossui = await _bibliotecaRepository.UsuarioJaPossuiJogoAsync(usuarioId, jogo.Id);

                if (!jaPossui)
                {
                    await _bibliotecaRepository.AdicionarAsync(usuarioId, jogo.Id);
                }
            }

            var compra = new HistoricoCompra
            {
                UsuarioId = usuarioId,
                DataCompra = DateTime.UtcNow,
                Itens = itens
            };

            await _historicoRepository.AdicionarAsync(compra);

            return Result.Success("Compra realizada com sucesso.");
        }

    }
}
