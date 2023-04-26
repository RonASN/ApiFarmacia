namespace Domain.Entidades
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
