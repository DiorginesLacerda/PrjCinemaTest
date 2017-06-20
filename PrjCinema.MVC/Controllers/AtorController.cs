using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrjCinema.MVC.Controllers
{
    public class AtorController : Controller
    {
        // GET: Ator
        public ActionResult Index()
        {
            return View();
        }

        // GET: Ator/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ator/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ator/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ator/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ator/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ator/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ator/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
