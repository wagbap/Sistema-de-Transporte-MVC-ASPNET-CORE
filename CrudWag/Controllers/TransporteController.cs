using CrudWag.Models;
using CrudWag.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CrudWag.Controllers
{
    public class TransporteController : Controller
    {
        private readonly ITransporteRepositorio _transporteRepositorio;

        public TransporteController(ITransporteRepositorio transporteRepositorio)
        {
            _transporteRepositorio = transporteRepositorio;
        }

        // VIEW
        [HttpGet]
        public IActionResult Index(string query)
        {
            var transporte = _transporteRepositorio.ListarTodos();
            return View(transporte);
        }

        public IActionResult Ver(int id)
        {
            TransporteModel transporte = _transporteRepositorio.ListarPorId(id);
            return View(transporte);
        }

        // CREATE
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(TransporteModel transporte)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (transporte.ImageFile != null)
                    {
                        var fileName = Path.GetFileNameWithoutExtension(transporte.ImageFile.FileName);
                        var extension = Path.GetExtension(transporte.ImageFile.FileName);
                        fileName = fileName + "_" + DateTime.Now.ToString("yymmssfff") + extension;

                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Uploads/", fileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            transporte.ImageFile.CopyTo(stream);
                        }
                        transporte.ImageURL = "/Uploads/" + fileName;
                    }
                    transporte = _transporteRepositorio.Create(transporte);
                    TempData["MensagemSucesso"] = "Trnasporte salvo com sucesso";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, Nao foi possivel guardar imagem, erro na validação";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = "Ops, não foi possível guardar o transporte, erro";
                return RedirectToAction("Index");
            }
        }

        // UPDATE
        public IActionResult Editar(int id)
        {
            TransporteModel transporte = _transporteRepositorio.ListarPorId(id);
            return View(transporte);
        }

        [HttpPost]
        public IActionResult Alterar(TransporteModel transporte)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (transporte.ImageFile != null)
                    {
                        var fileName = Path.GetFileNameWithoutExtension(transporte.ImageFile.FileName);
                        var extension = Path.GetExtension(transporte.ImageFile.FileName);
                        fileName = fileName + "_" + DateTime.Now.ToString("yymmssfff") + extension;

                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Uploads/", fileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            transporte.ImageFile.CopyTo(stream);
                        }
                        transporte.ImageURL = "/Uploads/" + fileName;
                    }
                    else
                    {
                        transporte.ImageURL = transporte.ImageURL;
                    }

                    transporte = _transporteRepositorio.Atualizar(transporte);
                    TempData["MensagemSucesso"] = "Transporte atualizado com sucesso";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não foi possível atualizar a imagem, erro na validação";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = "Ops, Nao foi possivel atualizar Livro, erro";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _transporteRepositorio.Apagar(id);
                    TempData["MensagemSucesso"] = $"Transporte apagado com sucesso";
                    return RedirectToAction("Index", "Transporte");
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não foi possível apagar Transporte, erro na validação";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = "Ops, não foi possível apagar Transporte, erro";
                return RedirectToAction("Index");
            }
        }


    }
 }

