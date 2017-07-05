using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using PrjCinema.Domain.Entities.Relacoes;
using PrjCinema.Domain.Entities.SerieFilme;
using PrjCinema.Domain.Interfaces.Repository;
using PrjCinema.Domain.Interfaces.Service;
using PrjCinema.MVC.Models;
using PrjCinema.Service.Service;

namespace PrjCinema.MVC.Controllers
{
    public class SerieController : Controller
    {
        private readonly ISerieService _serieService;
        private readonly IAtuaSerieService _atuaSerieService;
        private readonly IAtorService _atorService;
        private readonly AtuaSerieService atuaSerieService;
        private readonly SerieService serieService;

        public SerieController(SerieService serieService, AtuaSerieService atuaSerieService, AtorService atorService)
        {
            this.serieService = serieService;
            this.atuaSerieService = atuaSerieService;
            _atuaSerieService = atuaSerieService;
            _serieService = serieService;
            _atorService = atorService;
        }

        // GET: Serie
        public ActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<Serie>, IEnumerable<SerieModelView>>(_serieService.GetAll()));
        }

        // GET: Serie/Details/5
        public ActionResult Details(int id)
        {
           return View(Mapper.Map<Serie, SerieModelView>(_serieService.GetById(id)));
        }

        // GET: Ator/Details/5
        public ActionResult DetailsAtores(int id)
        {
           return View(Mapper.Map<IEnumerable<AtuaSerie>, IEnumerable<AtuaSerieModelView>>(_atuaSerieService.BuscaAtorPorSerie(id)));
        }



        // GET: Filme/AddAtuacaoFilme/id
        public ActionResult AddAtuacaoSerie(int id)
        {
            ViewBag.Atores = Mapper.Map<IEnumerable<Ator>, IEnumerable<AtorModelView>>(_atorService.GetAll());
            ViewBag.NomeSerie = Mapper.Map<Serie, SerieModelView>(_serieService.GetById(id)).Titulo;
            var atuacao = new AtuaSerieModelView();
            atuacao.SerieId = id;

            return View(atuacao);
        }



        //// POST: Filme/AddAtuacaoFilme/id
        [HttpPost]
        public ActionResult AddAtuacaoSerie(AtuaSerieModelView atuaSerie)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    atuaSerieService.AddAtuacaoFilme(Mapper.Map<AtuaSerieModelView, AtuaSerie>(atuaSerie));
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Create");

            }
            catch(Exception e)
            {
                ViewBag.Atores = Mapper.Map<IEnumerable<Ator>, IEnumerable<AtorModelView>>(_atorService.GetAll());
                ViewBag.Erro = e.Message;
                ViewBag.NomeSerie = atuaSerie.Serie.Titulo;
                return View(atuaSerie);
            }
        }

        // GET: Serie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Serie/Create
        [HttpPost]
        public ActionResult Create(SerieModelView serie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    serieService.AddFilme(Mapper.Map<SerieModelView, Serie>(serie));
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Create", serie);
            }
            catch (Exception e)
            {
                ViewBag.Erro = e.Message;
                return View(serie);
            }
        }

        // GET: Filme/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Mapper.Map<Serie, SerieModelView>(_serieService.GetById(id)));
        }

        // POST: Filme/Edit/5
        [HttpPost]
        public ActionResult Edit(SerieModelView serie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    serieService.EditaFilme(Mapper.Map<SerieModelView, Serie>(serie));
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Edit", serie);
            }
            catch (Exception e)
            {
                ViewBag.Erro = e.Message;
                return View(serie);
            }
        }

        //// GET: Serie/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Serie/Delete/5
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
