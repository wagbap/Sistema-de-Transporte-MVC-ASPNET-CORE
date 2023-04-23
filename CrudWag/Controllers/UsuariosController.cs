using Microsoft.AspNetCore.Mvc;
using CrudWag.Filters;
using CrudWag.Models;
using CrudWag.Repositorio;
using ControleContactos.Filters;
using CrudWag.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Linq;


namespace CrudWag.Controllers
{
    [PaginaRestritaAdmin]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IContatoRepositorio _contatoRepositorio;

     

        public UsuariosController(IUsuarioRepositorio usuarioRepositorio, IContatoRepositorio contatoRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _contatoRepositorio = contatoRepositorio;

        }
        public IActionResult Index()
        {
            var usuarios = _usuarioRepositorio.ListarTodos();
            return View(usuarios);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar (UsuarioModel usuario) {
            try
            {

                if (ModelState.IsValid)
                {


                    if (usuario.ImageFile != null)
                    {
                        var fileName = Path.GetFileNameWithoutExtension(usuario.ImageFile.FileName);
                        var extension = Path.GetExtension(usuario.ImageFile.FileName);
                        fileName = fileName + "_" + DateTime.Now.ToString("yymmssfff") + extension;

                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/usuarios", fileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            usuario.ImageFile.CopyTo(stream);
                        }
                        usuario.ImageURL = "/images/usuarios/" + fileName;

                    }

                    var usuarioExistente = _usuarioRepositorio.BuscarPorLogin(usuario.Login);

                    if (usuarioExistente.Login == usuario.Login)
                    {

                        TempData["MensagemSucesso"] = "Este usuário já está cadastrado";
                        return View(usuario);
                    }


                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                else
                {
                    // Adicione esta parte para verificar os erros do ModelState
                    var errors = ModelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .Select(x => new { x.Key, x.Value.Errors })
                        .ToArray();

                    TempData["MensagemSucesso"] = $"Erro na criação do Usuario. Erros: {string.Join(", ", errors.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))}";
                    return View(usuario);
                }
            }

            //return View(usuario);


            catch (Exception erro)
            {

                TempData["error"] = "Erro na criação do Usuario";
                return View(usuario);
            }

        }


        public IActionResult Ver(int id)
        {
            var usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

     

       
        [HttpGet]
        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Editar(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {
            try
            {
                UsuarioModel usuario = null;

                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenhaModel.Id,
                        Nome = usuarioSemSenhaModel.Nome,
                        ImageURL = usuarioSemSenhaModel.ImageURL,
                        Login = usuarioSemSenhaModel.Login,
                        Email = usuarioSemSenhaModel.Email,
                        Perfil = usuarioSemSenhaModel.Perfil,
                    };

                    // Adicione esta parte para atualizar a imagem do usuário, se fornecida
                    if (usuarioSemSenhaModel.ImageFile != null)
                    {
                        var fileName = Path.GetFileNameWithoutExtension(usuarioSemSenhaModel.ImageFile.FileName);
                        var extension = Path.GetExtension(usuarioSemSenhaModel.ImageFile.FileName);
                        fileName = fileName + "_" + DateTime.Now.ToString("yymmssfff") + extension;

                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/usuarios", fileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            usuarioSemSenhaModel.ImageFile.CopyTo(stream);
                        }
                        usuario.ImageURL = "/images/usuarios/" + fileName;
                    }

                    _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuario atualizado com sucesso";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Erro na atualização do Usuario";
                    return View(usuarioSemSenhaModel);
                }
            }
            catch (Exception erro)
            {
                TempData["error"] = "Erro na atualização do Usuario";
                return View();
            }
        } 

        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }
             
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuario Apagado com Sucesso";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não foi possivel apagar o Usuario";
                    return RedirectToAction("Index");
                }
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possivel apagar o Usuario, detalhe de erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
