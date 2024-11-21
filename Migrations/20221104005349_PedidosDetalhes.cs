using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneStore.Migrations
{
    public partial class PedidosDetalhes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_PEDIDO",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PedidoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalItensPedido = table.Column<int>(type: "int", nullable: false),
                    PedidoEnviado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PedidoEntregueEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_PEDIDO", x => x.PedidoId);
                });

            migrationBuilder.CreateTable(
                name: "T_PEDIDO_DETALHE",
                columns: table => new
                {
                    PedidoDetalheId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    RoupaId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_PEDIDO_DETALHE", x => x.PedidoDetalheId);
                    table.ForeignKey(
                        name: "FK_T_PEDIDO_DETALHE_T_PEDIDO_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "T_PEDIDO",
                        principalColumn: "PedidoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_PEDIDO_DETALHE_T_ROUPA_RoupaId",
                        column: x => x.RoupaId,
                        principalTable: "T_ROUPA",
                        principalColumn: "RoupaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_PEDIDO_DETALHE_PedidoId",
                table: "T_PEDIDO_DETALHE",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_T_PEDIDO_DETALHE_RoupaId",
                table: "T_PEDIDO_DETALHE",
                column: "RoupaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_PEDIDO_DETALHE");

            migrationBuilder.DropTable(
                name: "T_PEDIDO");
        }
    }
}
