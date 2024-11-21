using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneStore.Migrations
{
    public partial class PopularCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO T_CATEGORIA(CategoriaNome,CategoriaDescricao) " +
                "VALUES ('Camiseta','Camisetas de qualquer tipo.')");

            migrationBuilder.Sql("INSERT INTO T_CATEGORIA(CategoriaNome,CategoriaDescricao) " +
             "VALUES ('Calça','Calças de qualquer tipo.')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM T_CATEGORIA");
        }
    }
}
