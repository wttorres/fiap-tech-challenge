using Microsoft.EntityFrameworkCore;
using TechChallenge.GameStore.Domain.Jogos;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Infrastructure._Shared;

namespace TechChallenge.GameStore.Infrastructure.Jogos
{
    public class JogoRepository : IJogoRepository
    {
        private readonly GameStoreContext _context;

        public JogoRepository(GameStoreContext context)
        {
            _context = context;
        }

        public async Task<List<Jogo>> ObterPorIdsAsync(List<int> ids)
        {
            return await _context.Set<Jogo>()
                .Where(j => ids.Contains(j.Id))
                .ToListAsync();
        }

        public async Task<Jogo?> ObterPorIdAsync(int id)
        {
            return await _context.Set<Jogo>().FindAsync(id);
        }

        public async Task<Jogo?> ObterPorNome(string nome)
        {
            return await _context.Set<Jogo>()
                .FirstOrDefaultAsync(j => j.Nome.ToLower() == nome.ToLower());
        }

        public async Task<List<Jogo>> ObterTodosAsync()
        {
            return await _context.Set<Jogo>().ToListAsync();
        }

        public async Task<Result<Jogo>> AdicionarAsync(Jogo jogo)
        {
            _context.Add(jogo);
            await _context.SaveChangesAsync();
            return Result.Success(jogo);
        }

        public async Task AtualizarAsync(Jogo jogo)
        {
            _context.Update(jogo);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Jogo jogo)
        {
            _context.Remove(jogo);
            await _context.SaveChangesAsync();
        }
    }
}
