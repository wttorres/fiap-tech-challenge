using TechChallenge.GameStore.Domain._Shared;

namespace TechChallenge.GameStore.Domain.Usuarios;

public class Usuario
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Senha { get; private set; }
    public DateTime CriadoEm { get; private set; }
    public bool ReceberNotificacoes { get; private set; }

    public Perfil Perfil { get; set; } = Perfil.Usuario;

    public Usuario() { }

    private Usuario(string nome, string email, string senha)
    {
        Nome  = nome;
        Email = email;
        Senha = senha;
        CriadoEm = DateTime.UtcNow;
        ReceberNotificacoes = true;
    }

    public static Result<Usuario> Criar(string nome, string email, string senha)
    {
        if (string.IsNullOrWhiteSpace(nome))
            return Result.Failure<Usuario>("Nome é obrigatório.");

        if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            return Result.Failure<Usuario>("Email inválido.");

        var senhaValida = SenhaExtension.ValidarSenha(senha);
        if (!senhaValida.Sucesso)
            return Result.Failure<Usuario>(senhaValida.Erro);

        var senhaHash = SenhaExtension.GerarHash(senha);
        var usuario = new Usuario(nome, email.Trim().ToLower(), senhaHash);

        return Result.Success(usuario);
    }
    
    public Result<Usuario> Atualizar(string? nome, string? senha, bool? desejaReceberNotificacoes = null)
    {
        if (string.IsNullOrWhiteSpace(nome) && string.IsNullOrWhiteSpace(senha))
            return Result.Failure<Usuario>("Informe ao menos o e-mail ou a senha para atualizar.");

        if (!string.IsNullOrWhiteSpace(nome))
            Nome = nome;

        if (!string.IsNullOrWhiteSpace(senha))
        {
            var senhaValidada = SenhaExtension.ValidarSenha(senha);
            if (!senhaValidada.Sucesso)
                return Result.Failure<Usuario>(senhaValidada.Erro);

            Senha = SenhaExtension.GerarHash(senha);
        }

        if (desejaReceberNotificacoes.HasValue)
            ReceberNotificacoes = desejaReceberNotificacoes.Value;

        return Result.Success(this);
    }
    
    public Result<Usuario> AtualizarPerfil(Perfil novoPerfil)
    {
        if (!Enum.IsDefined(typeof(Perfil), novoPerfil))
            return Result.Failure<Usuario>("Perfil inválido.");

        if (Perfil == novoPerfil)
            return Result.Failure<Usuario>($"O usuário já possui o perfil {novoPerfil}.");

        Perfil = novoPerfil;
        return Result.Success(this);
    }
}
