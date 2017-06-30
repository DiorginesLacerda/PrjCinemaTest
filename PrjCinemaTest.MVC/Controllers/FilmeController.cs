using System;
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

    public class FilmeController : Controller
    {
        private readonly AtuaFilmeService atuaFilmeService;
        private readonly IFilmeService _filmeService;
        private readonly IAtuaFilmeService _atuaFilmeService;
        private readonly IAtorService _atorService;
        private readonly FilmeService filmeService;

        public FilmeController(FilmeService filmeService, AtuaFilmeService atuaFilmeService, AtorService atorService)
        {
            this.filmeService = filmeService;
            this.atuaFilmeService = atuaFilmeService;
            _atuaFilmeService = atuaFilmeService;
            _filmeService = filmeService;
            _atorService = atorService;
        }
        // GET: Filme
        public ActionResult Index()
        {
            var filmes = Mapper.Map<IEnumerable<Filme>, IEnumerable<FilmeModelView>>(_filmeService.GetAll());
            return View(filmes);
        }


        // GET: Filme/AddAtuacaoFilme/id
        public ActionResult AddAtuacaoFilme(int id) 
        {
            ViewBag.Atores = Mapper.Map<IEnumerable<Ator>, IEnumerable<AtorModelView>>(_atorService.GetAll());
            var viewFilme = Mapper.Map<Filme, FilmeModelView>(_filmeService.GetById(id));
            
            ViewBag.NomeFilme = viewFilme.Titulo;
            var atuacao = new AtuaFilmeModelView();
            atuacao.FilmeId = id;

            return View(atuacao);
        }



        //// POST: Filme/AddAtuacaoFilme/id
        [HttpPost]
        public ActionResult AddAtuacaoFilme(AtuaFilmeModelView atuaFilme)
        {
            
            ViewBag.NomeFilme = "Aqui jás o nome do filme";
            try
            {
                if (ModelState.IsValid)
                {
                    var atuacao = Mapper.Map<AtuaFilmeModelView, AtuaFilme>(atuaFilme);
                    atuaFilmeService.AddAtuacaoFilme(atuacao);

                    return RedirectToAction("Index");
                }

                return RedirectToAction("Create");

            }
            catch(Exception E)
            {
                ViewBag.Erro = E.Message;
                ViewBag.Atores = Mapper.Map<IEnumerable<Ator>, IEnumerable<AtorModelView>>(_atorService.GetAll());
                return View(atuaFilme);
            }
        }

        



        // GET: Filme/Details/5
        public ActionResult Details(int id)
        {
            var filme = Mapper.Map<Filme, FilmeModelView>(_filmeService.GetById(id));
            return View(filme);
        }

        // GET: Ator/Details/5
        public ActionResult DetailsAtores(int id)
        {
            var filmes = Mapper.Map<IEnumerable<AtuaFilme>, IEnumerable<AtuaFilmeModelView>>(_atuaFilmeService.BuscaAtorPorFilme(id));

            return View(filmes);
        }

        // GET: Filme/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Filme/Create
        [HttpPost]
        public ActionResult Create(FilmeModelView filme)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var filmeMap = Mapper.Map<FilmeModelView, Filme>(filme);
                    filmeService.AddFilme(filmeMap);
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Create", filme);

            }
            catch (Exception e)
            {
                ViewBag.Erro = e.Message;
                return View(filme);
            }
        }

        // GET: Filme/Edit/5
        public ActionResult Edit(int id)
        {
            var filmeMap = Mapper.Map<Filme, FilmeModelView>(_filmeService.GetById(id));
            
            return View(filmeMap);
        }

        // POST: Filme/Edit/5
        [HttpPost]
        public ActionResult Edit(FilmeModelView filme)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var filmeMap = Mapper.Map<FilmeModelView, Filme>(filme);
                    filmeService.EditaFilme(filmeMap);
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
