using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneStore.Models;
using OneStore.Repositories.Interfaces;
using OneStore.ViewModels;

namespace OneStore.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly IRoupaRepository _roupaRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(IRoupaRepository roupaRepository, CarrinhoCompra carrinhoCompra)
        {
            _roupaRepository = roupaRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItems();
            _carrinhoCompra.CarrinhoCompraItens = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel()
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };

            return View(carrinhoCompraVM);
        }

        [Authorize]
        public RedirectToActionResult AdicionarItemNoCarrinhoCompra(int roupaId)
        {
            var roupaSelecionada = _roupaRepository.GetRoupaByID(roupaId);

            if(roupaSelecionada != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(roupaSelecionada);
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        public RedirectToActionResult RemoverItemDoCarrinhoCompra(int roupaId)
        {
            var roupaSelecionada = _roupaRepository.GetRoupaByID(roupaId);

            if (roupaSelecionada != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(roupaSelecionada);
            }

            return RedirectToAction("Index");
        }
    }
}
