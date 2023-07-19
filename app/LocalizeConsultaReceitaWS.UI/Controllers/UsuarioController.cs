using LocalizeConsultaReceitaWS.Infra.Interfaces;
using Microsoft.AspNetCore.Mvc;
using LocalizeConsultaReceitaWS.Domain.Usuario;
using LocalizeConsultaReceitaWS.Services.Interfaces;

namespace LocalizeConsultaReceitaWS.UI.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioRepository usuarioRepository, IUsuarioService usuarioService)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioService = usuarioService;
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
           return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _usuarioService.CriarUsuario(usuario);

                    if (result)
                    {
                        TempData["success"] = "Usuario cadastrado com sucesso.";
                        return RedirectToAction("Index", "Login");
                    }

                    TempData["error"] = "Usuario Já cadastrado.";
                    return View();
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

        public ActionResult Edit(int id)
        {
            var session = HttpContext.Session.GetString("Email") ?? string.Empty;

            if (string.IsNullOrEmpty(session))
                return RedirectToAction("Index", "Login");

            return View();
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepository.Alterar(usuario);
                    TempData["success"] = "Dados alterados com sucesso.";
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

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _usuarioRepository.Deletar(id);
                return RedirectToAction("Index", "Login");
        }
    }
}
