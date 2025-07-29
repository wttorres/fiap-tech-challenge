using MediatR;
using TechChallenge.GameStore.Domain._Shared;

namespace TechChallenge.GameStore.Application.Jogos.Consultar
{
    public class ObterJogosAdquiridosQuery : IRequest<Result<List<JogoAdquiridoResponse>>>
    {
        public int UsuarioId { get; set; }

        public ObterJogosAdquiridosQuery(int usuarioId)
        {
            UsuarioId = usuarioId;
        }
    }
}
