using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using PrjCinema.Domain.Entities.Relacoes;
using PrjCinema.Domain.Entities.SerieFilme;
using PrjCinema.Domain.Interfaces.Service;
using PrjCinema.MVC.Models;
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
            return View(Mapper.Map<IEnumerable<Ator>, IEnumerable<AtorModelView>>(_atorService.GetAll()));
        }

        // GET: Ator/Details/5
        public ActionResult DetailsFilmes(int id)
        {
            ViewBag.Ator = Mapper.Map<Ator, AtorModelView>(_atorService.GetById(id)).Nome;
            return View(Mapper.Map<IEnumerable<AtuaFilme>, IEnumerable<AtuaFilmeModelView>>(_atuaFilmeService.BuscaFilmePorAtor(id)));
        }

        // GET: Ator/Details/5
        public ActionResult DetailsSeries(int id)
        {
            return View(Mapper.Map<IEnumerable<AtuaSerie>, IEnumerable<AtuaSerieModelView>>(_atuaSerieService.BuscaSeriePorAtor(id)));
        }

        // GET: Ator/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ator/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AtorModelView ator)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    atorService.AddAtor(Mapper.Map<AtorModelView, Ator>(ator));
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Create", ator);

            }
            catch (Exception e)
            {
                ViewBag.Erro = e.Message;
                return View(ator);
            }
        }

        // GET: Ator/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Mapper.Map<Ator, AtorModelView>(_atorService.GetById(id)));
        }

        // POST: Ator/Edit/5
        [HttpPost]
        public ActionResult Edit(AtorModelView ator)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    atorService.EditarAtor(Mapper.Map<AtorModelView, Ator>(ator));
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Edit", ator);
            }
            catch (Exception e)
            {
                ViewBag.Erro = e.Message;
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
