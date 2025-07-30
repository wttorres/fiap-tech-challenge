using TechChallenge.GameStore.Domain.Jogos;
using TechChallenge.GameStore.Domain.Usuarios;

namespace TechChallenge.GameStore.Domain.Compras
{
    public class BibliotecaJogo
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int JogoId { get; set; }
        public Jogo Jogo { get; set; }
    }
}
