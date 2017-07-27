using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.WebPages;
using AutoMapper;
using PrjCinema.Domain.Entities.SerieFilme;
using PrjCinema.Domain.Interfaces.Service;
using PrjCinema.MVC.Models;
using PrjCinema.MVC.Session;
using PrjCinema.Service.Service;

namespace PrjCinema.MVC.Controllers
{
    [TelaAuthorize(UserTelaPermission = "Serie")]
    public class SerieController : Controller
    {
        private readonly ISerieService _serieService;
        private readonly IAtorService _atorService;
        private readonly SerieService serieService;

        public SerieController(SerieService serieService, AtorService atorService)
        {
            this.serieService = serieService;
            _serieService = serieService;
            _atorService = atorService;
        }

        // GET: Serie
        public ActionResult Index()
        {
            return View(Mapper.Map<ICollection<Serie>, ICollection<SerieModelView>>(_serieService.GetAll()));
        }

        // GET: Serie/Details/5
        public ActionResult Details(int id)
        {
           return View(Mapper.Map<Serie, SerieModelView>(_serieService.GetById(id)));
        }

        // GET: Ator/Details/5
        public ActionResult DetailsAtores(int id)
        {
           return View(Mapper.Map<IEnumerable<Ator>, ICollection<AtorModelView>>(_atorService.BuscaAtoresPorSerie(id)));
        }

        // GET: Filme/AddAtuacaoFilme/id
        public ActionResult AddAtuacaoSerie(int id)
        {
            ViewBag.Atores = Mapper.Map<IEnumerable<Ator>, ICollection<AtorModelView>>(_atorService.GetAll());
            return View(Mapper.Map<Serie, SerieModelView>(_serieService.GetById(id)));
        }



        //// POST: Filme/AddAtuacaoFilme/id
        [HttpPost]
        public ActionResult AddAtuacaoSerie(SerieModelView atuaSerie, string atorId)
        {
            var getSerieComObjCorreto = _serieService.GetById(atuaSerie.Id);
            try
            {
                if (!ModelState.IsValid)
                {
                    
                    var idVindoDoViewBagDoAtor = _atorService.GetById(atorId.AsInt());
                    getSerieComObjCorreto.SerieAtores.Add(idVindoDoViewBagDoAtor);
                    serieService.Update(getSerieComObjCorreto);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Create");
            }
            catch (Exception E)
            {
                ViewBag.Erro = E.Message;
                ViewBag.Atores = Mapper.Map<ICollection<Ator>, ICollection<AtorModelView>>(_atorService.GetAll());
                return View(Mapper.Map<Serie, SerieModelView>(getSerieComObjCorreto));
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
