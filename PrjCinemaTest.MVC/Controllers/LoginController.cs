using System;
using System.Web.Mvc;
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
        public ActionResult Login(LoginModelView u)
        {

            try
            {
                // esta action trata o post (login)
                if (ModelState.IsValid) //verifica se é válido
                {
                    var usuario = _usuarioService.LoginUsuario(u.Email, u.Password);
                    Session["UsuarioLogado"] = usuario;
                    if (usuario != null)
                    {
                        //Session["usuarioLogadoID"] = _usuarioService.LoginUsuario(u.Email, u.Password).Id;
                        //Session["usuarioLogadoNome"] = _usuarioService.LoginUsuario(u.Email, u.Password).Nome;
                        //Session["emailUsuarioLogado"] = _usuarioService.LoginUsuario(u.Email, u.Password).Email;

                        Session["UsuarioLogado"] = usuario;//_usuarioService.LoginUsuario(u.Email, u.Password);

                        if (Session["UsuarioLogado"] == null)
                            return View(u);
                          //return ((MVC.Models.UsuarioModelView)Session["UsuarioLogado"]).Perfil == Perfil.Adminstrador;
                        
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
            if (Session["usuarioLogado"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login");

        }
    }
}
