using Microsoft.AspNetCore.Mvc;
using OneStore.Models;
using OneStore.Repositories.Interfaces;
using OneStore.ViewModels;

namespace OneStore.Controllers
{
    public class RoupaController : Controller
    {
        private readonly IRoupaRepository _roupaRepository;

        public RoupaController(IRoupaRepository roupaRepository)
        {
            _roupaRepository = roupaRepository;
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Roupa> roupas;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                roupas = _roupaRepository.GetRoupas.OrderBy(r => r.RoupaId);
                categoriaAtual = "Todos os lanches";
            }
            else
            {
                roupas = _roupaRepository.GetRoupas.Where(o => o.Categoria.CategoriaNome.Equals(categoria)).OrderBy(r => r.RoupaNome);

                categoriaAtual = categoria;
            }

            var roupaListViewModel = new RoupaListViewModel
            {
                Roupas = roupas,
                Categoria = categoriaAtual
            };

            return View(roupaListViewModel);
        }

        public IActionResult Details(int roupaId)
        {
            var roupa = _roupaRepository.GetRoupas.FirstOrDefault(r => r.RoupaId == roupaId);
            return View(roupa);
        }

        public ViewResult Search(string searchString)
        {
            IEnumerable<Roupa> roupas;
            string categoriaAtual = string.Empty;

            if(string.IsNullOrEmpty(searchString))
            {
                roupas = _roupaRepository.GetRoupas.OrderBy(p => p.RoupaId);
                categoriaAtual = "Todas as roupas";
            }
            else
            {
                roupas = _roupaRepository.GetRoupas.Where(p => p.RoupaNome.ToLower().Contains(searchString.ToLower()));

                if (roupas.Any())
                {
                    categoriaAtual = "Roupas";
                }
                else
                {
                    categoriaAtual = "Nenhuma roupa foi encontrada";
                }
            }

            return View("~/Views/Roupa/List.cshtml", new RoupaListViewModel
            {
                Roupas = roupas,
                Categoria = categoriaAtual
            });
        }
    }
}