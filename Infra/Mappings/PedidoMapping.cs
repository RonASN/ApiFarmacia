using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

            builder.Property(x => x.Total)
                   .IsRequired()
                   .HasColumnName("Total")
                   .HasColumnType("float");

            builder.Property(x => x.DataPedido)
                   .IsRequired()
                   .HasColumnName("DataPedido")
                   .HasColumnType("SMALLDATETIME")
                   .HasMaxLength(60)
                   .HasDefaultValueSql("GETDATE()");

            builder.HasOne(x => x.Cliente)
                   .WithMany(x => x.PedidoCliente)
                   .HasConstraintName("FK_Pedido_Cliente")
                   .OnDelete(DeleteBehavior.Cascade); 

            builder.HasMany(x => x.Produtos)
                   .WithMany(x => x.Pedidos)
                   .UsingEntity<Dictionary<string, object>>(
                        "ProdutosPedidos",
                        produto => produto
                            .HasOne<Produto>()
                            .WithMany()
                            .HasForeignKey("ProdutoId")
                            .HasConstraintName("FK_ProdutosPedidos_ProdutoId")
                            .OnDelete(DeleteBehavior.Cascade),
                        pedido => pedido
                            .HasOne<Pedido>()
                            .WithMany()
                            .HasForeignKey("FK_ProdutosPedidos_PedidoId")
                            .OnDelete(DeleteBehavior.Cascade));
        }
    }
}
