using CrudWag.Models;
using CrudWag.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CrudWag.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }



        public IActionResult Criar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index(string query)
        {
            var contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }

        [HttpPost]

        public IActionResult Criar(ContatoModel contato)
        {

            if (ModelState.IsValid)
            {
                _contatoRepositorio.Create(contato);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Ver(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListaPorId(id);
            return View(contato);
        }
        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListaPorId(id);
            return View(contato);
        }
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contato = _contatoRepositorio.Atualizar(contato);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Editar", contato);
                }
            }
            catch (Exception e)
            {
                return View();
            }
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListaPorId(id);
            return View(contato);
        }

    }
}
