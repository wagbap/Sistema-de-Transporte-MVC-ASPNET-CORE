using Microsoft.AspNetCore.Mvc;
using CrudWag.Helpers;
using CrudWag.Models;
using CrudWag.Repositorio;

namespace CrudWag.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        private readonly IEmail _email;
        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao, IEmail email)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
            _email = email;
        }
        public IActionResult Index()
        {
            if (_sessao.BuscarSessao() != null) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            
                            _sessao.CriarSessao(usuario);
                            var nome = usuario.Nome;
                            TempData["MensagemSucesso"] = $"Bem vindo {nome} novamente.";
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = $"Senha do usuário é inválida, tente novamente.";
                    }

                    TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s). Por favor, tente novamente.";
                }

                return View("Index");
            }
            catch (Exception)
            {
                TempData["error"] = "Erro no login";
                return View("Index");
            }
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessao();

            return RedirectToAction("Index", "Login");
        }

        public IActionResult RedefinirSenha()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EnviarLinkParaRedefinirSenha(RedefinirSenhaModel redefinirSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorEmailLogin(redefinirSenhaModel.Email, redefinirSenhaModel.Login);
                    if (usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();
                        string mensagem = $"Sua nova Senha é: {novaSenha}";

                        bool emailEnviado = _email.Enviar(usuario.Email, "Tracks Systems", mensagem);
                        if (emailEnviado)
                        {
                            _usuarioRepositorio.Atualizar(usuario);
                            TempData["MensagemSucesso"] = $"Enviamos para o seu email uma nova senha";
                        }
                        else
                        {
                            TempData["MensagemErro"] = $"Não conseguimos gerar uma nova senha tenta novamente";
                        }
            return RedirectToAction("Index", "Login");
        }

                    TempData["MensagenErro"] = $"Não conseguimos redefinir a sua senha";
                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagenErro"] = $"Não conseguimos redefinir a sua senha";
                return RedirectToAction("Index");
            }
        }
    }
}
