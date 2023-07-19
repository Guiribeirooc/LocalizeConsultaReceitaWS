using Microsoft.AspNetCore.Mvc;
using LocalizeConsultaReceitaWS.Infra.Interfaces;
using LocalizeConsultaReceitaWS.Domain.Login;

namespace LocalizeConsultaReceitaWS.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepository _loginRepository;

        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _loginRepository.Obter(login);

                    if (!result)
                    {
                        TempData["error"] = "Usuário ou senha está incorreto.";
                        return View();
                    }

                    HttpContext.Session.SetString("Email", login.Email);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["error"] = "Algum campo está faltando ser preenchido";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "Algum erro aconteceu - " + ex.Message;
                return View();
            }
        }
    }
}
