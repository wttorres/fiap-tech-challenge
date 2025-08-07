namespace TechChallenge.GameStore.Domain.Compras
{
    public interface IHistoricoCompraRepository
    {
        Task AdicionarAsync(HistoricoCompra compra);
        Task<List<HistoricoCompra>> ObterPorUsuarioIdAsync(int usuarioId);
    }
}
