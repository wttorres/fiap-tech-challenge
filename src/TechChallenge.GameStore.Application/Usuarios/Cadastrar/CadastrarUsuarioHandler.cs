using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Usuarios;

namespace TechChallenge.GameStore.Application.Usuarios.Cadastrar;

public class CadastrarUsuarioHandler : IRequestHandler<CadastrarUsuarioCommand, Result<string>>
{
    private readonly IUsuarioRepository _repository;

    public CadastrarUsuarioHandler(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<string>> Handle(CadastrarUsuarioCommand request, CancellationToken cancellationToken)
    {
        var existente = await _repository.ObterPorEmailAsync(request.Email);
        
        if (existente is not null)
            return Result.Failure<string>("Email já cadastrado.");

        return await CadastrarAsync(request);
    }

    private async Task<Result<string>> CadastrarAsync(CadastrarUsuarioCommand request)
    {
        var resultado = Usuario.Criar(request.Nome, request.Email, request.Senha);
        if (!resultado.Sucesso)
            return Result.Failure<string>(resultado.Erro);

        var adicionarResult = await _repository.AdicionarAsync(resultado.Valor);
        
        return !adicionarResult.Sucesso 
            ? Result.Failure<string>(adicionarResult.Erro) 
            : Result.Success(adicionarResult.Valor.Id.ToString());
    }
}