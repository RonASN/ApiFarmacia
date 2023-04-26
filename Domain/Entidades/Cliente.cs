namespace Domain.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public string? Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string? Estado { get; set; }
        public string? Quadra { get; set; }
        public string? Conjunto { get; set; }
        public string? Telefone { get; set; }
        public IEnumerable<Pedido> PedidoCliente { get; set; }
    }
}
