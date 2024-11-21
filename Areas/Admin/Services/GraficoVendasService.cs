using OneStore.Context;
using OneStore.Models;

namespace OneStore.Areas.Admin.Services
{
    public class GraficoVendasService
    {
        private readonly AppDbContext _context;

        public GraficoVendasService(AppDbContext context)
        {
            _context = context;
        }

        public List<RoupaGrafico> GetVendasRoupas(int dias = 360)
        {
            var data = DateTime.Now.AddDays(-dias);

            var roupas = (from pd in _context.T_PEDIDO_DETALHE
                          join r in _context.T_ROUPA on pd.RoupaId equals r.RoupaId
                          where pd.Pedido.PedidoEnviado >= data
                          group pd by new {pd.RoupaId, r.RoupaNome}
                          into g
                          select new
                          {
                              RoupaNome = g.Key.RoupaNome,
                              RoupaQuantidade = g.Sum(q => q.Quantidade),
                              RoupaValorTotal = g.Sum(a => a.Preco * a.Quantidade)
                          });

            var lista = new List<RoupaGrafico>();

            foreach(var item in roupas)
            {
                var roupa = new RoupaGrafico()
                {
                    RoupaNome = item.RoupaNome,
                    RoupaQuantidade = item.RoupaQuantidade,
                    RoupaValorTotal = item.RoupaValorTotal
                };

                lista.Add(roupa);
            }

            return lista;
        }
    }
}