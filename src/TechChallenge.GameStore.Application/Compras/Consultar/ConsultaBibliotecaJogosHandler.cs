using MediatR;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Compras;
using TechChallenge.GameStore.Domain.Compras.Interfaces;

namespace TechChallenge.GameStore.Application.Compras.Consultar
{
    public class ConsultaBibliotecaJogosHandler : IRequestHandler<ConsultaBibliotecaJogosQuery, Result<List<JogoAdquiridoResponse>>>
    {
        private readonly IBibliotecaJogosRepository _bibliotecaRepository;

        public ConsultaBibliotecaJogosHandler(IBibliotecaJogosRepository bibliotecaRepository)
        {
            _bibliotecaRepository = bibliotecaRepository;
        }

        public async Task<Result<List<JogoAdquiridoResponse>>> Handle(ConsultaBibliotecaJogosQuery request, CancellationToken cancellationToken)
        {
            var jogos = await _bibliotecaRepository.ObterPorUsuarioIdAsync(request.UsuarioId);

            var resposta = jogos
                .Select(j => new JogoAdquiridoResponse
                {
                    Nome = j.Jogo.Nome                                       
                })
                .ToList();

            return Result.Success(resposta);
        }
    }
}
