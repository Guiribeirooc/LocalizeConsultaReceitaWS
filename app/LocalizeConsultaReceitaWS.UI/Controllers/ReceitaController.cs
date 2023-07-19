using LocalizeConsultaReceitaWS.Domain.Cliente;
using LocalizeConsultaReceitaWS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LocalizeConsultaReceitaWS.UI.Controllers
{
    public class ReceitaController : Controller
    {
        private readonly IReceitaService _receitaService;

        public ReceitaController(IReceitaService receitaService)
        {
            _receitaService = receitaService;
        }
       
        public ActionResult Create()
        {
            var session = HttpContext.Session.GetString("Email") ?? string.Empty;

            if (string.IsNullOrEmpty(session))
                return RedirectToAction("Index", "Login");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _receitaService.ConsultarReceita(cliente);

                    if (result)
                    {
                        TempData["success"] = "Consulta realizada com sucesso.";
                        return RedirectToAction("Index", "Home");
                    }
                }
                TempData["error"] = "Consulta já realizada com este CNPJ.";
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
