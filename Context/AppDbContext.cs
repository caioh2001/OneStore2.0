using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OneStore.Models;

namespace OneStore.Context
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Categoria> T_CATEGORIA { get; set; }
        public DbSet<Roupa> T_ROUPA { get; set; }
        public DbSet<CarrinhoCompraItem> T_CARRINHO_COMPRA_ITENS { get; set; }
        public DbSet<Pedido> T_PEDIDO { get; set; }
        public DbSet<PedidoDetalhe> T_PEDIDO_DETALHE { get; set; }
    }
}
