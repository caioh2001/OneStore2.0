using OneStore.Models;
using OneStore.Context;
using OneStore.Repositories.Interfaces;

namespace OneStore.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoriaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Categoria> Categorias => _appDbContext.T_CATEGORIA;
    }
}
