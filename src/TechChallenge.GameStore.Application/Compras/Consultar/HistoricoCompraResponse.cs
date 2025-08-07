namespace TechChallenge.GameStore.Application.Compras.Consultar
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
