using System;
using System.Web.Mvc;
using PrjCinema.Domain.Interfaces.Repository;


using PrjCinema.MVC.Models;
using PrjCinema.Service.Service;

namespace PrjCinema.MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly UsuarioService _usuarioService;
        public LoginController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UsuarioModelView u)
        {
            
            try
            {
                // esta action trata o post (login)
                if (!ModelState.IsValid) //verifica se é válido
                {

                    if (_usuarioService.LoginUsuario(u.Email, u.Password) != null)
                    {
                        Session["usuarioLogadoID"] = _usuarioService.LoginUsuario(u.Email, u.Password).Id;
                        Session["usuarioLogadoNome"] = _usuarioService.LoginUsuario(u.Email, u.Password).Nome;
                        Session["emailUsuarioLogado"] = _usuarioService.LoginUsuario(u.Email, u.Password).Email;
                        return RedirectToAction("Index");
                    }
                }
                return View(u);
            }
            catch (Exception e)
            {
                ViewBag.Erro = e.Message;
                return View(u);
            }

        }

        public ActionResult Index()
        {
            if (Session["usuarioLogadoID"] != null)
                return RedirectToAction("Index", "Home");

            return RedirectToAction("Login");

        }
    }
}
