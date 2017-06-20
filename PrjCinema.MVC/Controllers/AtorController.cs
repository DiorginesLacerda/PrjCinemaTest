using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrjCinema.Domain.Interfaces.Repository;
using PrjCinema.Service.Service;

namespace PrjCinema.MVC.Controllers
{
    public class AtorController : Controller
    {

        private readonly IAtorService _atorService;
        private readonly IAtuaFilmeService _atuaFilmeService;
        private readonly IAtuaSerieService _atuaSerieService;
        public AtorController(AtorService atorService, AtuaFilmeService atuaFilmeService, AtuaSerieService atuaSerieService)
        {
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

        //// GET: Ator/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Ator/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Ator/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Ator/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Ator/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Ator/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Ator/Delete/5
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
