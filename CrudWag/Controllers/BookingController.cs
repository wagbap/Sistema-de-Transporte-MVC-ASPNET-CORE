using CrudWag.Models;
using CrudWag.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace CrudWag.Controllers
{
      
        public class BookingController : Controller
        {
            private readonly IBookingRepositorio _movieService;
            private readonly IMotoristaRepositorio _genService;
            public BookingController(IMotoristaRepositorio genService, IBookingRepositorio MovieService)
            {
                _movieService = MovieService;
                _genService = genService;
            }

    
              public IActionResult Add()
            {
                var model = new BookingModel();
                model.MotoristaList = _genService.BuscarTodos().Select(a => new SelectListItem { Text = a.Nome, Value = a.Id.ToString() });
                return View(model);
            }

        [HttpPost]
        public IActionResult Add(BookingModel model)
        {
           

            if (model.file != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(model.file.FileName);
                var extension = Path.GetExtension(model.file.FileName);
                fileName = fileName + "_" + DateTime.Now.ToString("yymmssfff") + extension;

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Uploads/", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    model.file.CopyTo(stream);
                }
                model.ProvaCartaConducao = "/Uploads/" + fileName;
            }
            model.MotoristaList = _genService.BuscarTodos().Select(a => new SelectListItem { Text = a.Nome, Value = a.Id.ToString() });
            var result = _movieService.Add(model);

                if (result)
                {
                    TempData["msg"] = "Added Successfully";
                    return RedirectToAction(nameof(Add));
                }
                else
                {
                    TempData["msg"] = "Error on server side";
                    return View(model);

                } 
            
        }

        public IActionResult Edit(int id)
            {
                var model = _movieService.GetById(id);
                var selectedGenres = _movieService.GetMotoristaByBookingId(model.Id);
                MultiSelectList multiGenreList = new MultiSelectList(_genService.BuscarTodos(), "Id", "MotoristaNames", selectedGenres);
                model.MultiGenreList = multiGenreList;
                return View(model);
            }

            [HttpPost]
            public IActionResult Edit(BookingModel model)
            {
                var selectedGenres = _movieService.GetMotoristaByBookingId(model.Id);
                MultiSelectList multiGenreList = new MultiSelectList(_genService.BuscarTodos(), "Id", "MotoristaNames", selectedGenres);
                model.MultiGenreList = multiGenreList;
                if (!ModelState.IsValid)
                    return View(model);

                var result = _movieService.Update(model);
                if (result)
                {
                    TempData["msg"] = "Added Successfully";
                    return RedirectToAction(nameof(MovieList));
                }
                else
                {
                    TempData["msg"] = "Error on server side";
                    return View(model);
                }
            }

        public IActionResult MovieList()
            {
                var data = this._movieService.BuscarTodos();
                return View(data);
            }

            public IActionResult Delete(int id)
            {
                var result = _movieService.Delete(id);
                return RedirectToAction(nameof(MovieList));
            }

       }
    }

