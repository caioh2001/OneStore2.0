using OneStore.Models;

namespace OneStore.ViewModels
{
    public class RoupaListViewModel
    {
        public IEnumerable<Roupa> Roupas { get; set; }

        public string Categoria { get; set; }
    }
}