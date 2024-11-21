using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneStore.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_CATEGORIA",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaNome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CategoriaDescricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_CATEGORIA", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "T_ROUPA",
                columns: table => new
                {
                    RoupaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoupaNome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    RoupaDescricao = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    RoupaPreco = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    RoupaUrlImagem = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RoupaDestaque = table.Column<bool>(type: "bit", nullable: false),
                    EmEstoque = table.Column<bool>(type: "bit", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ROUPA", x => x.RoupaId);
                    table.ForeignKey(
                        name: "FK_T_ROUPA_T_CATEGORIA_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "T_CATEGORIA",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_ROUPA_CategoriaId",
                table: "T_ROUPA",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_ROUPA");

            migrationBuilder.DropTable(
                name: "T_CATEGORIA");
        }
    }
}
