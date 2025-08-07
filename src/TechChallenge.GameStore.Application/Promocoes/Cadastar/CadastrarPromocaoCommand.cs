using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;
using MediatR;
using TechChallenge.GameStore.Domain._Shared;

namespace TechChallenge.GameStore.Application.Promocoes.Cadastar;

public class CadastrarPromocaoCommand : IRequest<Result<string>>
{
    [Required(ErrorMessage = "O nome da promoção é obrigatório.")]
    [SwaggerSchema("Nome da promoção", Nullable = false)]
    public string Nome { get; set; } = null!;

    [SwaggerSchema("Descrição opcional da promoção", Nullable = true)]
    public string? Descricao { get; set; }

    [Required(ErrorMessage = "O desconto percentual é obrigatório.")]
    [Range(1, 100, ErrorMessage = "O desconto deve estar entre 1% e 100%.")]
    [SwaggerSchema("Desconto percentual aplicado na promoção")]
    public decimal DescontoPercentual { get; set; }

    [Required(ErrorMessage = "A data de início é obrigatória.")]
    [SwaggerSchema("Data de início da promoção")]
    public DateTime DataInicio { get; set; }

    [Required(ErrorMessage = "A data de fim é obrigatória.")]
    [SwaggerSchema("Data de término da promoção")]
    public DateTime DataFim { get; set; }

    [Required(ErrorMessage = "É necessário informar pelo menos um jogo.")]
    [MinLength(1, ErrorMessage = "A promoção deve conter ao menos um ID de jogo.")]
    [SwaggerSchema("Lista de IDs dos jogos incluídos na promoção")]
    public List<int>? JogosIds { get; set; } = new();
}