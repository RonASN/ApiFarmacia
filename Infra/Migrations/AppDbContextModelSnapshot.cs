﻿// <auto-generated />
using System;
using Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infra.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entidades.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Tipo");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Domain.Entidades.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Conjunto")
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Conjunto");

                    b.Property<string>("Cpf")
                        .HasMaxLength(11)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("cpf");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Email");

                    b.Property<string>("Estado")
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Estado");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Nome");

                    b.Property<string>("Quadra")
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Quadra");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Senha");

                    b.Property<string>("Telefone")
                        .HasMaxLength(12)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Telefone");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Cpf" }, "IX_Cliente_Cpf");

                    b.HasIndex(new[] { "Email" }, "IX_Cliente_Email");

                    b.HasIndex(new[] { "Senha" }, "IX_Cliente_Senha");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Domain.Entidades.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataPedido")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(60)
                        .HasColumnType("SMALLDATETIME")
                        .HasColumnName("DataPedido")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<double>("Total")
                        .HasColumnType("float")
                        .HasColumnName("Total");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Domain.Entidades.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Descricao");

                    b.Property<int>("FK_Produtos_Categoria")
                        .HasColumnType("int");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Imagem");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Nome");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer")
                        .HasColumnName("Quantidade");

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("integer")
                        .HasColumnName("Valor");

                    b.HasKey("Id");

                    b.HasIndex("FK_Produtos_Categoria");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("ProdutosPedidos", b =>
                {
                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.HasKey("PedidoId", "ProdutoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ProdutosPedidos");
                });

            modelBuilder.Entity("Domain.Entidades.Pedido", b =>
                {
                    b.HasOne("Domain.Entidades.Cliente", "Cliente")
                        .WithMany("PedidoCliente")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Pedido_Cliente");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Domain.Entidades.Produto", b =>
                {
                    b.HasOne("Domain.Entidades.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("FK_Produtos_Categoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("ProdutosPedidos", b =>
                {
                    b.HasOne("Domain.Entidades.Pedido", null)
                        .WithMany()
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ProdutosPedidos_PedidoId");

                    b.HasOne("Domain.Entidades.Produto", null)
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ProdutosPedidos_ProdutoId");
                });

            modelBuilder.Entity("Domain.Entidades.Categoria", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("Domain.Entidades.Cliente", b =>
                {
                    b.Navigation("PedidoCliente");
                });
#pragma warning restore 612, 618
        }
    }
}