using MediatR;
using System.ComponentModel.DataAnnotations;
using TechChallenge.GameStore.Domain._Shared;

namespace TechChallenge.GameStore.Application.Jogos.Atualizar
{
    public class AtualizarJogoCommand : IRequest<Result<bool>>
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preço é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Preço deve ser maior que zero.")]
        public decimal Preco { get; set; }
    }
}
