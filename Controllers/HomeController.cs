using Microsoft.AspNetCore.Mvc;
using OneStore.Models;
using OneStore.Repositories.Interfaces;
using OneStore.ViewModels;
using System.Diagnostics;

namespace OneStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRoupaRepository _roupaRepository;

        public HomeController(IRoupaRepository roupaRepository)
        {
            _roupaRepository = roupaRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                RoupasPreferidas = _roupaRepository.RoupasPreferidas
            };

            return View(homeViewModel);
        }

        public IActionResult Demo()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}