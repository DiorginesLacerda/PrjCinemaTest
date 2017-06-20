using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrjCinema.Domain.Entities.SerieFilme;
using PrjCinema.Domain.Interfaces.Repository;
using PrjCinema.Service.Service;

namespace PrjCinema.MVC.Controllers
{

    public class FilmeController : Controller
    {
        private readonly IFilmeService _filmeService;
        private readonly IAtuaFilmeService _atuaFilmeService;

        public FilmeController(FilmeService filmeService, AtuaFilmeService atuaFilmeService)
        {
            _atuaFilmeService = atuaFilmeService;
            _filmeService = filmeService;
        }
        // GET: Filme
        public ActionResult Index()
        {
            return View( _filmeService.GetAll());
        }

        // GET: Filme/Details/5
        public ActionResult Details(int id)
        {
            return View(_filmeService.GetById(id));
        }

        // GET: Ator/Details/5
        public ActionResult DetailsAtores(int id)
        {
            var filmes = _atuaFilmeService.BuscaAtorPorFilme(id);

            return View(filmes);
        }

        // GET: Filme/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Filme/Create
        [HttpPost]
        public ActionResult Create(Filme filme)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _filmeService.Add(filme);
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Create", filme);

            }
            catch
            {
                return View(filme);
            }
        }

        // GET: Filme/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View(_filmeService.GetById(id));
        }

        // POST: Filme/Edit/5
        [HttpPost]
        public ActionResult Edit(Filme filme)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _filmeService.Update(filme);
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Edit", filme);
            }
            catch
            {
                return View();
            }
        }

        //// GET: Filme/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Filme/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
