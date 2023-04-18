using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.Valor)
                .IsRequired()
                .HasColumnName("Valor")
                .HasColumnType("double")
                .HasMaxLength(100);

            builder.Property(x => x.Quantidade)
                .IsRequired()
                .HasColumnName("Quantidade")
                .HasColumnType("integer");

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnName("Descricao")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);

            builder.Property(x => x.Imagem)
                .IsRequired()
                .HasColumnName("Imagem")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(500);

            builder.HasOne(x => x.Categoria)
                   .WithMany(x => x.Produtos)
                   .HasForeignKey("FK_Produtos_Categoria")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
