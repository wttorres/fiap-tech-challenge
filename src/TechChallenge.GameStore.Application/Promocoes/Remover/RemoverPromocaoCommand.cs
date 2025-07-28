using System.ComponentModel.DataAnnotations;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;
using TechChallenge.GameStore.Domain._Shared;

namespace TechChallenge.GameStore.Application.Promocoes.Remover;

public class RemoverPromocaoCommand : IRequest<Result<string>>
{
    [Required(ErrorMessage = "O código da promoção é obrigatório.")]
    [SwaggerSchema("Código da promoção", Nullable = false)]
    public int PromocaoId { get; set; }
}