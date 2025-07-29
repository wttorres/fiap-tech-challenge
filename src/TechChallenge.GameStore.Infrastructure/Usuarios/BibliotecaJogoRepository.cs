using Microsoft.EntityFrameworkCore;
using TechChallenge.GameStore.Domain.Usuarios;
using TechChallenge.GameStore.Infrastructure._Shared;

namespace TechChallenge.GameStore.Infrastructure.Usuarios
{
    public class BibliotecaJogosRepository : IBibliotecaJogosRepository
    {
        private readonly GameStoreContext _context;

        public BibliotecaJogosRepository(GameStoreContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(int usuarioId, int jogoId)
        {
            var entidade = new BibliotecaJogo
            {
                UsuarioId = usuarioId,
                JogoId = jogoId
            };

            _context.Set<BibliotecaJogo>().Add(entidade);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UsuarioJaPossuiJogoAsync(int usuarioId, int jogoId)
        {
            return await _context.Set<BibliotecaJogo>()
                .AnyAsync(b => b.UsuarioId == usuarioId && b.JogoId == jogoId);
        }

        public async Task<List<BibliotecaJogo>> ObterPorUsuarioIdAsync(int usuarioId)
        {
            return await _context.Set<BibliotecaJogo>()
                .Include(b => b.Jogo)
                .Where(b => b.UsuarioId == usuarioId)
                .ToListAsync();
        }
    }
}
