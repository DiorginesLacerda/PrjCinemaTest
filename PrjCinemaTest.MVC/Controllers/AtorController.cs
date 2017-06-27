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
    public class AtorController : Controller
    {

        private readonly IAtorService _atorService;
        private readonly IAtuaFilmeService _atuaFilmeService;
        private readonly IAtuaSerieService _atuaSerieService;
        private readonly AtorService atorService;
        public AtorController(AtorService atorService, AtuaFilmeService atuaFilmeService, AtuaSerieService atuaSerieService)
        {
            this.atorService = atorService;
            _atorService = atorService;
            _atuaFilmeService = atuaFilmeService;
            _atuaSerieService = atuaSerieService;
        }
        // GET: Ator
        public ActionResult Index()
        {   
            var ator = _atorService.GetAll();
            return View(ator);
        }

        // GET: Ator/Details/5
        public ActionResult DetailsFilmes(int id)
        {
            var filmes = _atuaFilmeService.BuscaFilmePorAtor(id);
            
            return View(filmes);
        }

        // GET: Ator/Details/5
        public ActionResult DetailsSeries(int id)
        {
            
            var series = _atuaSerieService.BuscaSeriePorAtor(id);

            return View(series);
        }

        // GET: Ator/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ator/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ator ator)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    if (atorService.AtorExiste(ator))
                    {
                        ViewBag.Erro = "Ator ja existe";
                        throw new Exception("Ator ja existe");
                    }
                    _atorService.Add(ator);
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Create", ator);

            }
            catch
            {
                return View(ator);
            }
        }

        // GET: Ator/Edit/5
        public ActionResult Edit(int id)
        {
            var atorEdit = _atorService.GetById(id);
            return View(atorEdit);
        }

        // POST: Ator/Edit/5
        [HttpPost]
        public ActionResult Edit(Ator ator)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _atorService.Update(ator);
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Edit", ator);
            }
            catch
            {
                return View(ator);
            }
        }

        
        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _atorService.Remove(_atorService.GetById(id)); 
            
            return RedirectToAction("Index");
        }
    }
}
