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

    public async Task<Result<Jogo>> AtualizarAsync(Jogo jogo)
    {
        try
        {
            _context.Set<Jogo>().Update(jogo);
            await _context.SaveChangesAsync();
            return Result.Success(jogo);
        }
        catch (Exception ex)
        {
            return Result.Failure<Jogo>($"Erro ao atualizar jogo: {ex.Message}");
        }
    }

    public async Task<Result<string>> InativarJogoAsync(int jogoId)
    {
        var jogos = await ObterAsync(new[] { jogoId });
        var jogo = jogos.FirstOrDefault();
        if (jogo == null)
            return Result.Failure<string>("Jogo não encontrado.");

        jogo.Inativar();

        var resultado = await AtualizarAsync(jogo);
        if (!resultado.Sucesso)
            return Result.Failure<string>(resultado.Erro);

        return Result.Success("Jogo inativado com sucesso");
    }

    public async Task<Result<string>> AtivarJogoAsync(int jogoId)
    {
        var jogos = await ObterAsync(new[] { jogoId });
        var jogo = jogos.FirstOrDefault();
        if (jogo == null)
            return Result.Failure<string>("Jogo não encontrado.");

        jogo.Ativar();

        var resultado = await AtualizarAsync(jogo);
        if (!resultado.Sucesso)
            return Result.Failure<string>(resultado.Erro);

        return Result.Success("Jogo ativado com sucesso");
    }
}