using OneStore.Context;
using OneStore.Models;
using OneStore.Repositories.Interfaces;

namespace OneStore.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoRepository(AppDbContext appDbContext, CarrinhoCompra carrinhoCompra)
        {
            _appDbContext = appDbContext;
            _carrinhoCompra = carrinhoCompra;
        }

        public void CriarPedido(Pedido pedido)
        {
            pedido.PedidoEnviado = DateTime.Now;
            _appDbContext.T_PEDIDO.Add(pedido);
            _appDbContext.SaveChanges();

            var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItens;

            foreach(var item in carrinhoCompraItens)
            {
                var pedidoDetail = new PedidoDetalhe()
                {
                    Quantidade = item.Quantidade,
                    RoupaId = item.Roupa.RoupaId,
                    PedidoId = pedido.PedidoId,
                    Preco = item.Roupa.RoupaPreco
                };

                _appDbContext.T_PEDIDO_DETALHE.Add(pedidoDetail);
            }
            _appDbContext.SaveChanges();
        }
    }
}
