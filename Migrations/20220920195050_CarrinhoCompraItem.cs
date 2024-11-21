using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneStore.Migrations
{
    public partial class CarrinhoCompraItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_CARRINHO_COMPRA_ITENS",
                columns: table => new
                {
                    CarrinhoCompraItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoupaId = table.Column<int>(type: "int", nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    CarrinhoCompraId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_CARRINHO_COMPRA_ITENS", x => x.CarrinhoCompraItemId);
                    table.ForeignKey(
                        name: "FK_T_CARRINHO_COMPRA_ITENS_T_ROUPA_RoupaId",
                        column: x => x.RoupaId,
                        principalTable: "T_ROUPA",
                        principalColumn: "RoupaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_CARRINHO_COMPRA_ITENS_RoupaId",
                table: "T_CARRINHO_COMPRA_ITENS",
                column: "RoupaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_CARRINHO_COMPRA_ITENS");
        }
    }
}
