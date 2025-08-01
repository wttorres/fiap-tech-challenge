using MediatR;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Usuarios;

namespace TechChallenge.GameStore.Application.Usuarios.Promover;

public class PromoverUsuarioCommand : IRequest<Result<string>>
{
    [Required]
    [SwaggerSchema("Id do usuário a ser promovido")]
    public int Id { get; set; }

    [Required]
    [SwaggerSchema("Novo perfil do usuário")]
    public Perfil NovoPerfil { get; set; }
}
