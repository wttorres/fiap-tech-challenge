using System.Collections.Generic;
using MediatR;
using TechChallenge.GameStore.Domain._Shared;

namespace TechChallenge.GameStore.Application.Compras.Consultar
{
    public class ConsultaBibliotecaJogosQuery : IRequest<Result<List<JogoAdquiridoResponse>>>
    {
        public int UsuarioId { get; set; }

        public ConsultaBibliotecaJogosQuery(int usuarioId)
        {
            UsuarioId = usuarioId;
        }
    }
}
