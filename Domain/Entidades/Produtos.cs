namespace Domain.Entidades
{
    public class Produto
    {
        public string Nome { get; set; }
        public string Valor { get; set; }
        public int Quantidade { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get;set; }
        public IEnumerable<Pedido> Pedidos { get; set; }
        public Categoria Categoria { get; set; }
    }
}
