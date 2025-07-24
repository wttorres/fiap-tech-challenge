using MediatR;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge.GameStore.Domain._Shared;

namespace TechChallenge.GameStore.Application.Usuarios.Atualizar;

public class AtualizarCommand : IRequest<Result<string>>
{
    [Required]
    [SwaggerSchema("ID do usuário a ser atualizado")]
    public int Id { get; set; }

    [SwaggerSchema("Nome do usuário")]
    public string? Nome { get; set; }

    [EmailAddress]
    [SwaggerSchema("Email do usuário")]
    public string? Email { get; set; }

    [SwaggerSchema("Senha do usuário (opcional)")]
    public string? Senha { get; set; }
}
