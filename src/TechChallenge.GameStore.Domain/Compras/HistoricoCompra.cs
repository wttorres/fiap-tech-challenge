using TechChallenge.GameStore.Domain.Usuarios;

namespace TechChallenge.GameStore.Domain.Compras
{
    public class HistoricoCompra
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataCompra { get; set; }
        public List<ItemCompra> Itens { get; set; } = new();
    }
}
