using MediatR;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Repositories.Usuarios;

namespace TechChallenge.GameStore.Application.Usuarios.Cadastrar;

public class CadastrarHandler : IRequestHandler<CadastrarCommand, Result<string>>
{
    private readonly IUsuarioRepository _repository;

    public CadastrarHandler(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<string>> Handle(CadastrarCommand request, CancellationToken cancellationToken)
    {
        var existente = await _repository.ObterPorEmailAsync(request.Email);
       
        if (existente != null)
            return Result.Failure<string>("Email já cadastrado.");

        var resultado = Usuario.Criar(request.Nome, request.Email, request.Senha);
        if (!resultado.Sucesso)
            return Result.Failure<string>(resultado.Erro);

        var usuarioSalvo = await _repository.AdicionarAsync(resultado.Valor);

        return Result.Success(usuarioSalvo.Id.ToString());
    }
}