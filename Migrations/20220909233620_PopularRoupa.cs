using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneStore.Migrations
{
    public partial class PopularRoupa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO T_ROUPA(RoupaNome,RoupaDescricao,RoupaPreco,RoupaUrlImagem,RoupaDestaque,EmEstoque, CategoriaId) " +
                "VALUES('Camiseta Lacoste Azul', 'Camiseta feita com algodão 30.1 na cor azul',80.00, '/images/CamisetaAzul.jpg', 1, 1, 1)");

            migrationBuilder.Sql("INSERT INTO T_ROUPA(RoupaNome,RoupaDescricao,RoupaPreco,RoupaUrlImagem,RoupaDestaque,EmEstoque, CategoriaId) " +
                "VALUES('Camiseta Lacoste Cinza', 'Camiseta feita com algodão 30.1 na cor cinza',80.00, '/images/CamisetaCinza.jpg', 1, 1, 1)");

            migrationBuilder.Sql("INSERT INTO T_ROUPA(RoupaNome,RoupaDescricao,RoupaPreco,RoupaUrlImagem,RoupaDestaque,EmEstoque, CategoriaId) " +
                "VALUES('Camiseta Lacoste Verde', 'Camiseta feita com algodão 30.1 na cor verde',80.00, '/images/CamisetaVerde.jpg', 1, 1, 1)");

            migrationBuilder.Sql("INSERT INTO T_ROUPA(RoupaNome,RoupaDescricao,RoupaPreco,RoupaUrlImagem,RoupaDestaque,EmEstoque, CategoriaId) " +
                "VALUES('Camiseta Lacoste Preta', 'Camiseta feita com algodão 30.1 na cor preta',120.00, '/images/CamisetaPreta.jpg', 1, 1, 1)");

            migrationBuilder.Sql("INSERT INTO T_ROUPA(RoupaNome,RoupaDescricao,RoupaPreco,RoupaUrlImagem,RoupaDestaque,EmEstoque, CategoriaId) " +
                "VALUES('Calça Jeans Escura', 'Calça feita com jeans escuro',180.00, '/images/CalcaJeansEscura.jpg', 1, 1, 2)");

            migrationBuilder.Sql("INSERT INTO T_ROUPA(RoupaNome,RoupaDescricao,RoupaPreco,RoupaUrlImagem,RoupaDestaque,EmEstoque, CategoriaId) " +
                "VALUES('Calça Jeans Clara', 'Calça feita com jeans claro', 120.00, '/images/CalcaJeansClara.jpg', 1, 1, 2)");

            migrationBuilder.Sql("INSERT INTO T_ROUPA(RoupaNome,RoupaDescricao,RoupaPreco,RoupaUrlImagem,RoupaDestaque,EmEstoque, CategoriaId) " +
                "VALUES('Calça Preta', 'Calça feita com sarja na cor preta',140.00, '/images/CalcaPreta.jpg', 1, 1, 2)");

            migrationBuilder.Sql("INSERT INTO T_ROUPA(RoupaNome,RoupaDescricao,RoupaPreco,RoupaUrlImagem,RoupaDestaque,EmEstoque, CategoriaId) " +
                "VALUES('Calça Beje', 'Calça feita com sarja na cor beje',100.00, '/images/CalcaBeje.jpg', 1, 1, 2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM T_ROUPA");
        }
    }
}
