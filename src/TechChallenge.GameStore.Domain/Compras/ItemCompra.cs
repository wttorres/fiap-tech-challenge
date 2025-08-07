using TechChallenge.GameStore.Domain._Shared;
using TechChallenge.GameStore.Domain.Jogos;

namespace TechChallenge.GameStore.Domain.Compras
{
    public class ItemCompra : Base
    {
        public int HistoricoCompraId { get; set; }
        public HistoricoCompra HistoricoCompra { get; set; }
        public int JogoId { get; set; }
        public Jogo Jogo { get; set; }
        public decimal PrecoPago { get; set; }
    }
}
