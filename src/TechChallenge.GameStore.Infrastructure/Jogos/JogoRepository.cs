using Microsoft.EntityFrameworkCore;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Jogos;
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

        public async Task<Jogo?> ObterPorNome(string nome)
        {
            var jogo = await _context.Set<Jogo>()
                .AsNoTracking()
                .Where(j => j.Nome.ToLower().Equals(nome.ToLower()))
                .FirstOrDefaultAsync();

            return jogo;
        }

        public async Task<Result<Jogo>> AdicionarAsync(Jogo jogo)
        {
            _context.Set<Jogo>().Add(jogo);
            await _context.SaveChangesAsync();

            return Result.Success(jogo);
        }        
    }
}
