using Microsoft.EntityFrameworkCore;
using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Usuarios;
using TechChallenge.GameStore.Infrastructure._Shared;

namespace TechChallenge.GameStore.Infrastructure.Usuarios;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly GameStoreContext _context;

    public UsuarioRepository(GameStoreContext context)
    {
        _context = context;
    }

    public async Task<Usuario?> ObterPorIdAsync(int id)
    {
        return await _context.Set<Usuario>()
                             .AsNoTracking()
                             .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<List<Usuario>> ObterTodosAsync()
    {
        return await _context.Set<Usuario>().ToListAsync();
    }

    public async Task<Usuario?> ObterPorEmailAsync(string email)
    {
        return await _context.Set<Usuario>()
            .AsNoTracking()
            .Where(x => x.Email == email)
            .FirstOrDefaultAsync();
    }


    public async Task<Result<Usuario>> AdicionarAsync(Usuario usuario)
    {
        try
        {
            await _context.Set<Usuario>().AddAsync(usuario);
            await _context.SaveChangesAsync();

            return Result.Success(usuario);
        }
        catch (Exception ex)
        {
            return Result.Failure<Usuario>($"Erro ao adicionar usuário: {ex.Message}");
        }
    }

    public async Task<Usuario?> ObterPorIdAsync(int id)
    {
        return await _context.Set<Usuario>().FindAsync(id);
    }

    public async Task<Result<Usuario>> AtualizarAsync(Usuario usuario)
    {
        try
        {
            _context.Set<Usuario>().Update(usuario);
            await _context.SaveChangesAsync();
            return Result.Success(usuario);
        }
        catch (Exception ex)
        {
            return Result.Failure<Usuario>($"Erro ao atualizar usuário: {ex.Message}");
        }
    }


}