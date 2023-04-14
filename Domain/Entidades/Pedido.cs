namespace Domain.Entidades
{
    public class Pedido
    {
        public double Total { get; set; }
        public DateTime DataPedido { get; set; }
        public Cliente Cliente { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
