using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.SessionState;
using System.Web.WebPages;
using AutoMapper;
using PrjCinema.Domain.Entities.SerieFilme;
using PrjCinema.Domain.Interfaces.Service;
using PrjCinema.MVC.Models;
using PrjCinema.Service.Service;

namespace PrjCinema.MVC.Controllers
{
    [Authorize]
    public class AtorController : Controller
    {
        private readonly SerieService _serieService;
        private readonly FilmeService _filmeService;
        private readonly IAtorService _atorService;
        private readonly AtorService atorService;
        public AtorController(AtorService atorService, FilmeService filmeService, SerieService serieService)
        {
            _serieService = serieService;
            _filmeService = filmeService;
            this.atorService = atorService;
            _atorService = atorService;

        }


        // GET: Ator
        public ActionResult Index()
        {
            return View(Mapper.Map<ICollection<Ator>, ICollection<AtorModelView>>(_atorService.GetAll()));

        }

        // GET: Ator/Edit/5
        public ActionResult AddAtuacaoFilme(int id)
        {
            ViewBag.Filmes = Mapper.Map<IEnumerable<Filme>, ICollection<FilmeModelView>>(_filmeService.GetAll());
            return View(Mapper.Map<Ator, AtorModelView>(_atorService.GetById(id)));
        }

        // POST: Ator/Edit/5
        [HttpPost]
        public ActionResult AddAtuacaoFilme(AtorModelView ator, int filmeId)
        {
            var getAtorComObjCorreto = _atorService.GetById(ator.Id);
            try
            {
                if (!ModelState.IsValid)
                {
                    var idVindoDoViewBagDoFilme = _filmeService.GetById(filmeId);
                    getAtorComObjCorreto.AtorFilmes.Add(idVindoDoViewBagDoFilme);
                    atorService.Update(getAtorComObjCorreto);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Create");
            }
            catch (Exception E)
            {
                ViewBag.Erro = E.Message;
                ViewBag.Atores = Mapper.Map<ICollection<Ator>, ICollection<AtorModelView>>(_atorService.GetAll());
                return View(Mapper.Map<Ator, AtorModelView>(getAtorComObjCorreto));
            }

        }

        // GET: Ator/Edit/5
        public ActionResult AddAtuacaoSerie(int id)
        {
            ViewBag.Series = Mapper.Map<IEnumerable<Serie>, ICollection<SerieModelView>>(_serieService.GetAll());
            return View(Mapper.Map<Ator, AtorModelView>(_atorService.GetById(id)));
        }

        // POST: Ator/Edit/5
        [HttpPost]
        public ActionResult AddAtuacaoSerie(AtorModelView ator, string serieId)
        {
            var getAtorComObjCorreto = _atorService.GetById(ator.Id);
            try
            {
                if (!ModelState.IsValid)
                {

                    var idVindoDoViewBagDaSerie = _filmeService.GetById(serieId.AsInt());
                    getAtorComObjCorreto.AtorFilmes.Add(idVindoDoViewBagDaSerie);
                    atorService.Update(getAtorComObjCorreto);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Create");
            }
            catch (Exception E)
            {
                ViewBag.Erro = E.Message;
                ViewBag.Atores = Mapper.Map<ICollection<Ator>, ICollection<AtorModelView>>(_atorService.GetAll());
                return View(Mapper.Map<Ator, AtorModelView>(getAtorComObjCorreto));
            }
        }


        // GET: Ator/Details/5
        public ActionResult DetailsFilmes(int id)
        {
            ViewBag.Ator = Mapper.Map<Ator, AtorModelView>(_atorService.GetById(id)).Nome;
            return View(Mapper.Map<IEnumerable<Filme>, ICollection<FilmeModelView>>(_filmeService.BuscaFilmesPorAtor(id)));
        }

        // GET: Ator/Details/5
        public ActionResult DetailsSeries(int id)
        {
            return View(Mapper.Map<IEnumerable<Serie>, ICollection<SerieModelView>>(_serieService.BuscaSeriesPorAtor(id)));
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
                    atorService.Add(Mapper.Map<AtorModelView, Ator>(ator));
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
                if (!ModelState.IsValid)
                {
                    atorService.Update(Mapper.Map<AtorModelView, Ator>(ator));
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
