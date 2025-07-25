using Microsoft.EntityFrameworkCore;
using TechChallenge.GameStore.Domain.Jogos;
using TechChallenge.GameStore.Infrastructure._Shared;

namespace TechChallenge.GameStore.Infrastructure.Jogos;

public class JogoRepository : IJogoRepository
{
    private readonly GameStoreContext _context;

    public JogoRepository(GameStoreContext context)
    {
        _context = context;
    }

    public async Task<List<Jogo>> ObterAsync(IEnumerable<int> jogosIds)
    {
        return await _context.Set<Jogo>()
            .Where(j => jogosIds.Contains(j.Id))
            .ToListAsync();
    }
}