using Microsoft.EntityFrameworkCore;
using OneStore.Context;
using OneStore.Models;

namespace OneStore.Areas.Admin.Services
{
    public class RelatorioRoupasService
    {
        private readonly AppDbContext _context;

        public RelatorioRoupasService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Roupa>> GetRoupasReport()
        {
            var roupas = await _context.T_ROUPA.ToListAsync();

            if(roupas is null)
            {
                return default(IEnumerable<Roupa>);
            }
            else
            {
                return roupas;
            }
        }

        public async Task<IEnumerable<Categoria>> GetCategoriasReport()
        {
            var categorias = await _context.T_CATEGORIA.ToListAsync();

            if (categorias is null)
            {
                return default(IEnumerable<Categoria>);
            }
            else
            {
                return categorias;
            }
        }
    }
}
