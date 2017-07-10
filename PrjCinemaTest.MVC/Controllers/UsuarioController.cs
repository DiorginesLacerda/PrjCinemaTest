using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using PrjCinema.Domain.Entities;
using PrjCinema.Domain.Interfaces.Service;
using PrjCinema.MVC.Models;
using PrjCinema.Service.Service;

namespace PrjCinema.MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly UsuarioService __usuarioService;
        public UsuarioController(UsuarioService usuarioService, EnderecoService enderecoService)
        {
            __usuarioService = usuarioService;
            _usuarioService = usuarioService;
        }
        // GET: Usuario
        public ActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioModelView>>(_usuarioService.GetAll()));
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View(Mapper.Map<Usuario, UsuarioModelView>(_usuarioService.GetById(id)));
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioModelView usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    __usuarioService.AddUsuario(Mapper.Map<UsuarioModelView, Usuario>(usuario));
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Create", usuario);
            }
            catch (Exception e)
            {
                ViewBag.Erro = e.Message;
                return View(usuario);
            }


        }

        //// GET: Usuario/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Usuario/Edit/5
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

        //// GET: Usuario/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Usuario/Delete/5
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
