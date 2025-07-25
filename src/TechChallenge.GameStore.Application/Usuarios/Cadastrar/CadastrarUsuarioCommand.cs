using System.ComponentModel.DataAnnotations;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;
using TechChallenge.GameStore.Domain._Shared;

namespace TechChallenge.GameStore.Application.Usuarios.Cadastrar;

public class CadastrarUsuarioCommand : IRequest<Result<string>>
{
    [Required]
    [SwaggerSchema("Nome completo do usuário")]
    public string Nome { get; set; }

    [Required]
    [EmailAddress]
    [SwaggerSchema("Email do usuário")]
    public string Email { get; set; }

    [Required]
    [SwaggerSchema("Senha para acesso")]
    public string Senha { get; set; }
}