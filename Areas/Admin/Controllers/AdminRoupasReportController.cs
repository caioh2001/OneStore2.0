using FastReport.Data;
using FastReport.Export.PdfSimple;
using FastReport.Web;
using LanchesMac.Areas.Admin.FastReportUtils;
using Microsoft.AspNetCore.Mvc;
using OneStore.Areas.Admin.Services;

namespace OneStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminRoupasReportController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly RelatorioRoupasService _relatorioRoupasService;

        public AdminRoupasReportController(IWebHostEnvironment webHostEnvironment, RelatorioRoupasService relatorioRoupasService)
        {
            _webHostEnvironment = webHostEnvironment;
            _relatorioRoupasService = relatorioRoupasService;
        }

        public async Task<ActionResult> RoupasCategoriaReport()
        {
            var webReport = new WebReport();
            var mssqlDataConnection = new MsSqlDataConnection();

            webReport.Report.Dictionary.AddChild(mssqlDataConnection);
            webReport.Report.Load(Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot/reports", "RoupasCategoria.frx"));

            var roupas = HelperFastReport.GetTable(await _relatorioRoupasService.GetRoupasReport(), "RoupasReport");
            var categorias = HelperFastReport.GetTable(await _relatorioRoupasService.GetCategoriasReport(), "CategoriasReport");

            webReport.Report.RegisterData(roupas, "RoupasReport");
            webReport.Report.RegisterData(categorias, "CategoriasReport");

            return View(webReport);
        }

        [Route("RoupasCategoriasPDF")]
        public async Task<ActionResult> RoupasCategoriaPDF()
        {
            var webReport = new WebReport();
            var mssqlDataConnection = new MsSqlDataConnection();

            webReport.Report.Dictionary.AddChild(mssqlDataConnection);
            webReport.Report.Load(Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot/reports", "RoupasCategoria.frx"));

            var roupas = HelperFastReport.GetTable(await _relatorioRoupasService.GetRoupasReport(), "RoupasReport");
            var categorias = HelperFastReport.GetTable(await _relatorioRoupasService.GetCategoriasReport(), "CategoriasReport");

            webReport.Report.RegisterData(roupas, "RoupasReport");
            webReport.Report.RegisterData(categorias, "CategoriasReport");
            webReport.Report.Prepare();

            Stream stream = new MemoryStream();

            webReport.Report.Export(new PDFSimpleExport(), stream);
            stream.Position = 0;

            //return File(stream, "application/zip", "RoupaCategoria.pdf");

            return new FileStreamResult(stream, "application/pdf");
        }
    }
}
