using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

            builder.Property(x => x.Cpf)
                .HasColumnName("cpf")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(11);

            builder.HasIndex(x => x.Cpf, "IX_Cliente_Cpf");

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            builder.HasIndex(x => x.Email, "IX_Cliente_Email");

            builder.Property(x => x.Senha)
                .IsRequired()
                .HasColumnName("Senha")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(8);

            builder.HasIndex(x => x.Senha, "IX_Cliente_Senha");

            builder.Property(x => x.Estado)
                   .HasColumnName("Estado")
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(20);

            builder.Property(x => x.Quadra)
                   .HasColumnName("Quadra")
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(20);

            builder.Property(x => x.Conjunto)
                   .HasColumnName("Conjunto")
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(80);

            builder.Property(x => x.Telefone)
                   .HasColumnName("Telefone")
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(12);

        }
    }
}
