using OneStore.Models;

namespace OneStore.ViewModels
{
    public class PedidoRoupaViewModel
    {
        public Pedido Pedido { get; set; }

        public IEnumerable<PedidoDetalhe> PedidoDetalhes { get; set; }
    }
}