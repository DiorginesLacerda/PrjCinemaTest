using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using PrjCinema.Domain.Entities.Relacoes;
using PrjCinema.Domain.Entities.SerieFilme;
using PrjCinema.Domain.Interfaces.Repository;
using PrjCinema.MVC.Models;
using PrjCinema.Service.Service;

namespace PrjCinema.MVC.Controllers
{
    public class SerieController : Controller
    {
        private readonly ISerieService _serieService;
        private readonly IAtuaSerieService _atuaSerieService;
        private readonly IAtorService _atorService;

        public SerieController(SerieService serieService, AtuaSerieService atuaSerieService, AtorService atorService)
        {
            _atuaSerieService = atuaSerieService;
            _serieService = serieService;
            _atorService = atorService;
        }

        // GET: Serie
        public ActionResult Index()
        {
            var serie = Mapper.Map<IEnumerable<Serie>, IEnumerable<SerieModelView>>(_serieService.GetAll());
            return View(serie);
        }

        // GET: Serie/Details/5
        public ActionResult Details(int id)
        {
            var serie = Mapper.Map<Serie, SerieModelView>(_serieService.GetById(id));
            return View(serie);
        }

        // GET: Ator/Details/5
        public ActionResult DetailsAtores(int id)
        {
            var series = _atuaSerieService.BuscaAtorPorSerie(id);

            return View(series);
        }

        // GET: Serie/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Filme/AddAtuacaoFilme/id
        public ActionResult AddAtuacaoSerie(int id)
        {
            ViewBag.Atores = _atorService.GetAll();
            var viewSerie = _serieService.GetById(id);

            ViewBag.NomeSerie = viewSerie.Titulo;
            var atuacao = new AtuaSerie();
            atuacao.SerieId = id;

            return View(atuacao);
        }



        //// POST: Filme/AddAtuacaoFilme/id
        [HttpPost]
        public ActionResult AddAtuacaoSerie(AtuaSerie atuaSerie)
        {

            try
            {
                if (ModelState.IsValid)
                {


                    _atuaSerieService.Add(atuaSerie);
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Create");

            }
            catch
            {
                return View(atuaSerie);
            }
        }

        // POST: Serie/Create
        [HttpPost]
        public ActionResult Create(Serie serie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _serieService.Add(serie);
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Create", serie);

            }
            catch
            {
                return View(serie);
            }
        }

        // GET: Serie/Edit/5
        public ActionResult Edit(int id)
        {

            return View(_serieService.GetById(id));
        }

        // POST: Serie/Edit/5
        [HttpPost]
        public ActionResult Edit(Serie serie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _serieService.Update(serie);
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Edit", serie);
            }
            catch
            {
                return View();
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
