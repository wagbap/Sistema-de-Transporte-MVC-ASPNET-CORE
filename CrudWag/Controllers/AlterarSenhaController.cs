using Microsoft.AspNetCore.Mvc;
using CrudWag.Helpers;
using CrudWag.Models;
using CrudWag.Repositorio;

namespace CrudWag.Controllers
{
    public class AlterarSenhaController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public AlterarSenhaController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _sessao = sessao;
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Alterar(AlterarSenhaModel alterarSenhaModel)
        {
            try
            {
                UsuarioModel usuarioLogado = _sessao.BuscarSessao();
                alterarSenhaModel.Id = usuarioLogado.Id;
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.AlterarSenha(alterarSenhaModel);
                    TempData["MensagemSucesso"] = "Senha Alterada Com Sucesso";
                    return RedirectToAction("Index", "Usuarios", alterarSenhaModel);
                }
                TempData["MensagemErro"] = $"Não foi possivel alterar a sua senha";
                return View("Index", alterarSenhaModel);
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Não foi possivel alterar a sua senha";
                return View("Index", alterarSenhaModel);
            }
        }
    }
}
