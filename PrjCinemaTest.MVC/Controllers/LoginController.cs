using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using PrjCinema.Data.Context;
using PrjCinema.Domain.Entities;
using PrjCinema.MVC.Models;

namespace PrjCinema.MVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UsuarioModelView u)
        {
            // esta action trata o post (login)
            if (!ModelState.IsValid) //verifica se é válido
            {
                using (ProjectContext dc = new ProjectContext())
                {
                    var u2 = Mapper.Map<UsuarioModelView, Usuario>(u);
                    var v = dc.Usuarios.Where(a => a.Email.Equals(u2.Email) && a.Password.Equals(u2.Password)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["usuarioLogadoID"] = v.Id.ToString();
                        Session["nomeUsuarioLogado"] = v.Email;
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(u);
        }

        public ActionResult Index()
        {
            if (Session["usuarioLogadoID"] != null)
                return RedirectToAction("Index", "Home");

            return RedirectToAction("Login");

        }
    }
}
