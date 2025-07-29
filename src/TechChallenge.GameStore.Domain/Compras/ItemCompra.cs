using TechChallenge.GameStore.Domain.Jogos;

namespace TechChallenge.GameStore.Domain.Compras
{
    public class ItemCompra
    {
        public int Id { get; set; }
        public int HistoricoCompraId { get; set; }
        public HistoricoCompra HistoricoCompra { get; set; }
        public int JogoId { get; set; }
        public Jogo Jogo { get; set; }
        public decimal PrecoPago { get; set; }
    }
}
