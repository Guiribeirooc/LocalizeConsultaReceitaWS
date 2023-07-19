using LocalizeConsultaReceitaWS.Infra.Interfaces;
using LocalizeConsultaReceitaWS.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace LocalizeConsultaReceitaWS.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IPedidoRepository pedidoRepository, ILogger<HomeController> logger)
        {
            _pedidoRepository = pedidoRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var session = HttpContext.Session.GetString("Email") ?? string.Empty;

            if (string.IsNullOrEmpty(session))
                return RedirectToAction("Index", "Login");

            var pedidos = _pedidoRepository.Obter();
            return View(pedidos);
        }

        public FileResult DownloadFile(string id)
        {
            return File(Encoding.UTF8.GetBytes(id), "application/octet-stream", "resultado.txt");
        }
        
        public IActionResult Privacy()
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