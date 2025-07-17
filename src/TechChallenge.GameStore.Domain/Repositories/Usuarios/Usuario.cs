using TechChallenge.GameStore.Domain._Shared;

namespace TechChallenge.GameStore.Domain.Repositories.Usuarios
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public DateTime CriadoEm { get; private set; }
        
        private Usuario() { }

        private Usuario(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            CriadoEm = DateTime.UtcNow;
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

    }
}
