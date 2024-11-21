using Microsoft.AspNetCore.Mvc;
using OneStore.Areas.Admin.Services;

namespace OneStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminGraficoController : Controller
    {
        private readonly GraficoVendasService _graficoVendasService;

        public AdminGraficoController(GraficoVendasService graficoVendasService)
        {
            _graficoVendasService = graficoVendasService ?? throw new ArgumentNullException(nameof(graficoVendasService));
        }

        public JsonResult VendasRoupas(int dias)
        {
            var roupasVendasTotais = _graficoVendasService.GetVendasRoupas(dias);

            return Json(roupasVendasTotais);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult VendasMensal()
        {
            return View();
        }

        [HttpGet]
        public IActionResult VendasSemanal()
        {
            return View();
        }
    }
}