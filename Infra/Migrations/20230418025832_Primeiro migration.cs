using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class Primeiromigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cpf = table.Column<string>(type: "NVARCHAR(11)", maxLength: 11, nullable: true),
                    Nome = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR(8)", maxLength: 8, nullable: false),
                    Estado = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: true),
                    Quadra = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: true),
                    Conjunto = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: true),
                    Telefone = table.Column<string>(type: "NVARCHAR(12)", maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    Valor = table.Column<string>(type: "double", maxLength: 100, nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR(200)", maxLength: 200, nullable: false),
                    Imagem = table.Column<string>(type: "NVARCHAR(500)", maxLength: 500, nullable: false),
                    FK_Produtos_Categoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Categorias_FK_Produtos_Categoria",
                        column: x => x.FK_Produtos_Categoria,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<double>(type: "float", nullable: false),
                    DataPedido = table.Column<DateTime>(type: "SMALLDATETIME", maxLength: 60, nullable: false, defaultValueSql: "GETDATE()"),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Cliente",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdutosPedidos",
                columns: table => new
                {
                    FK_ProdutosPedidos_PedidoId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosPedidos", x => new { x.FK_ProdutosPedidos_PedidoId, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_ProdutosPedidos_Pedidos_FK_ProdutosPedidos_PedidoId",
                        column: x => x.FK_ProdutosPedidos_PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutosPedidos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Cpf",
                table: "Clientes",
                column: "cpf");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Email",
                table: "Clientes",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Senha",
                table: "Clientes",
                column: "Senha");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_FK_Produtos_Categoria",
                table: "Produtos",
                column: "FK_Produtos_Categoria");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosPedidos_ProdutoId",
                table: "ProdutosPedidos",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutosPedidos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
