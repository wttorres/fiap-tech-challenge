using Microsoft.EntityFrameworkCore;
using TechChallenge.GameStore.Domain.Compras;
using TechChallenge.GameStore.Domain.Compras.Interfaces;
using TechChallenge.GameStore.Infrastructure._Shared;

namespace TechChallenge.GameStore.Infrastructure.Compras
{
    public class HistoricoCompraRepository : IHistoricoCompraRepository
    {
        private readonly GameStoreContext _context;

        public HistoricoCompraRepository(GameStoreContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(HistoricoCompra compra)
        {
            _context.Set<HistoricoCompra>().Add(compra);
            await _context.SaveChangesAsync();
        }

        public async Task<List<HistoricoCompra>> ObterPorUsuarioIdAsync(int usuarioId)
        {
            return await _context.Set<HistoricoCompra>()
                .Include(h => h.Itens)
                .ThenInclude(i => i.Jogo)
                .Where(h => h.UsuarioId == usuarioId)
                .ToListAsync();
        }
    }
}
