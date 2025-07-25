using Microsoft.EntityFrameworkCore;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Promocoes;
using TechChallenge.GameStore.Infrastructure._Shared;

namespace TechChallenge.GameStore.Infrastructure.Promocoes;

public class PromocaoRepository : IPromocaoRepository
{
    private readonly GameStoreContext _context;

    public PromocaoRepository(GameStoreContext context)
    {
        _context = context;
    }

    public async Task<bool> ExisteAsync(string nome)
    {
        return await _context
            .Set<Promocao>()
            .AnyAsync(p => p.Nome.ToUpper() == nome.ToUpper());
    }

    public async Task<Result<Promocao>> AdicionarAsync(Promocao promocao)
    {
        try
        {
            await _context.Set<Promocao>().AddAsync(promocao);
            await _context.SaveChangesAsync();
            
            return Result.Success(promocao);
        }
        catch (Exception ex)
        {
            return Result.Failure<Promocao>($"Erro ao salvar promoção: {ex.Message}");
        }
    }

    public async Task<List<PromocaoJogo>> ObterPorJogosIdsAsync(List<int> jogoIds)
    {
        return await _context.Set<PromocaoJogo>()
            .Where(j => jogoIds.Contains(j.JogoId))
            .Include(x => x.Jogo)
            .ToListAsync();
    }
}