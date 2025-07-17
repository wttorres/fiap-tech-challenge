using Microsoft.EntityFrameworkCore;
using TechChallenge.GameStore.Domain.Repositories.Usuarios;
using TechChallenge.GameStore.Infrastructure._Shared;

namespace TechChallenge.GameStore.Infrastructure.Repositories.Usuarios;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly GameStoreContext _context;

    public UsuarioRepository(GameStoreContext context)
    {
        _context = context;
    }
    
    public async Task<List<Usuario>> ObterTodosAsync()
    {
        return await _context.Set<Usuario>().ToListAsync();
    }

    public Task<Usuario?> ObterPorEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<Usuario> AdicionarAsync(Usuario usuario)
    {
        throw new NotImplementedException();
    }
}