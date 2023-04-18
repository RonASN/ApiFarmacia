namespace Domain.Entidades
{
    public class Pedido
    {
        public int Id { get; set; }
        public double Total { get; set; }
        public DateTime DataPedido { get; set; }
        public Cliente Cliente { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
