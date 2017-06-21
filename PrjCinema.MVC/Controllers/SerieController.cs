using System.Web.Mvc;
using PrjCinema.Domain.Entities.SerieFilme;
using PrjCinema.Domain.Interfaces.Repository;
using PrjCinema.Service.Service;

namespace PrjCinema.MVC.Controllers
{
    public class SerieController : Controller
    {
        private readonly ISerieService _serieService;
        private readonly IAtuaSerieService _atuaSerieService;

        public SerieController(SerieService serieService, AtuaSerieService atuaSerieService)
        {
            _atuaSerieService = atuaSerieService;
            _serieService = serieService;
        }

        // GET: Serie
        public ActionResult Index()
        {
            return View(_serieService.GetAll());
        }

        // GET: Serie/Details/5
        public ActionResult Details(int id)
        {
            return View(_serieService.GetById(id));
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
