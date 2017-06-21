using System.Web.Mvc;
using PrjCinema.Domain.Entities.Relacoes;
using PrjCinema.Domain.Entities.SerieFilme;
using PrjCinema.Domain.Interfaces.Repository;
using PrjCinema.Service.Service;

namespace PrjCinema.MVC.Controllers
{

    public class FilmeController : Controller
    {
        private readonly IFilmeService _filmeService;
        private readonly IAtuaFilmeService _atuaFilmeService;
        private readonly IAtorService _atorService;

        public FilmeController(FilmeService filmeService, AtuaFilmeService atuaFilmeService, AtorService atorService)
        {
            _atuaFilmeService = atuaFilmeService;
            _filmeService = filmeService;
            _atorService = atorService;
        }
        // GET: Filme
        public ActionResult Index()
        {
            return View( _filmeService.GetAll());
        }


        // GET: Filme/AddAtuacaoFilme/id
        public ActionResult AddAtuacaoFilme(int id, Filme filme)
        {
            ViewBag.Atores = _atorService.GetAll();
            var viewFilme = _filmeService.GetById(id);

            ViewBag.NomeFilme = viewFilme.Titulo;
            var atuacao = new AtuaFilme();
            atuacao.FilmeId = id;

            return View(atuacao);
        }



        //// POST: Filme/AddAtuacaoFilme/id
        [HttpPost]
        public ActionResult AddAtuacaoFilme(AtuaFilme atuaFilme)
        {
           
            try
            {
                if (ModelState.IsValid)
                {


                    _atuaFilmeService.Add(atuaFilme);
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Create");

            }
            catch
            {
                return View(atuaFilme);
            }
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
