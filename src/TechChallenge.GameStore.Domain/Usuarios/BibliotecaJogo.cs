using TechChallenge.GameStore.Domain.Jogos;

namespace TechChallenge.GameStore.Domain.Usuarios
{
    public class BibliotecaJogo
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int JogoId { get; set; }
        public Jogo Jogo { get; set; }
    }
}
