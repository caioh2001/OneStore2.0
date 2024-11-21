using Microsoft.EntityFrameworkCore;
using OneStore.Context;
using OneStore.Models;
using OneStore.Repositories.Interfaces;

namespace OneStore.Repositories
{
    public class RoupaRepository : IRoupaRepository
    {
        private readonly AppDbContext _appDbContext;

        public RoupaRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public IEnumerable<Roupa> GetRoupas => _appDbContext.T_ROUPA.Include(c => c.Categoria);

        public IEnumerable<Roupa> RoupasPreferidas => _appDbContext.T_ROUPA.Where(r => r.RoupaDestaque).Include(c => c.Categoria);

        public Roupa GetRoupaByID(int id)
        {
           return _appDbContext.T_ROUPA.FirstOrDefault(r => r.RoupaId == id);
        }
    }
}
