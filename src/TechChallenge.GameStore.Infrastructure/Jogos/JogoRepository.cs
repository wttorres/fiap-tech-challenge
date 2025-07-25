using Microsoft.EntityFrameworkCore;
using TechChallenge.GameStore.Domain._Shared;
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

    public async Task<Jogo?> ObterPorNome(string nome)
    {
        var nomeLower = nome.ToLower();

        return await _context.Set<Jogo>()
            .AsNoTracking()
            .FirstOrDefaultAsync(j => j.Nome.ToLower() == nomeLower);
    }

    public async Task<Result<Jogo>> AdicionarAsync(Jogo jogo)
    {
        try
        {
            _context.Set<Jogo>().Add(jogo);
            await _context.SaveChangesAsync();
            return Result.Success(jogo);
        }
        catch (Exception ex)
        {
            return Result.Failure<Jogo>($"Erro ao salvar jogo: {ex.Message}");
        }
    }
}