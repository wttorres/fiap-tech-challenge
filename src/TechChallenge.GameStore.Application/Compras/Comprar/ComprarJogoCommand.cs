using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;
using TechChallenge.GameStore.Domain._Shared;

namespace TechChallenge.GameStore.Application.Compras.Comprar
{
    public class ComprarJogoCommand : IRequest<Result<string>>
    {
        [Required(ErrorMessage = "O ID do usuário é obrigatório.")]
        [SwaggerSchema("ID do Usuário que está realizando a compra")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "É necessário informar pelo menos um jogo.")]
        [MinLength(1, ErrorMessage = "Selecione pelo menos um jogo para comprar.")]
        [SwaggerSchema("Lista de IDs dos jogos que serão comprados")]
        public List<int> JogosIds { get; set; }
    }
}
