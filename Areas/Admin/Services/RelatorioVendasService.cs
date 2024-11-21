using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using OneStore.Context;
using OneStore.Models;

namespace OneStore.Areas.Admin.Services
{
    public class RelatorioVendasService
    {
        private readonly AppDbContext _context;

        public RelatorioVendasService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pedido>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var resultado = from obg in _context.T_PEDIDO select obg;

            if (minDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado <= maxDate.Value);
            }

            return await resultado.Include(i => i.PedidoItens)
                                  .ThenInclude(x => x.Roupa)
                                  .OrderByDescending(y => y.PedidoEnviado).ToListAsync();
        }
    }
}
