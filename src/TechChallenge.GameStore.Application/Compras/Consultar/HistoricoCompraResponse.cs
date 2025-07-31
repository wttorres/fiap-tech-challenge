namespace TechChallenge.GameStore.Application.HistoricoCompras
{
    public class HistoricoCompraResponse
    {
        public class CompraDto
        {
            public DateTime DataCompra { get; set; }
            public string NomeJogo { get; set; }
            public decimal ValorBase { get; set; }
            public decimal ValorComDesconto { get; set; }
        }
    }
}
