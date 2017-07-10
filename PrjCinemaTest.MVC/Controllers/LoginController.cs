using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using PrjCinema.Domain.Entities;
using PrjCinema.MVC.Models;
using PrjCinema.Service.Service;

namespace PrjCinema.MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly GrupoAcessoUsuarioService _grupoAcessoUsuarioService;
        private readonly GrupoAcessoPermissaoService _grupoAcessoPermissaoService;
        private readonly UsuarioService _usuarioService;
        public LoginController(UsuarioService usuarioService, GrupoAcessoUsuarioService grupoAcessoUsuarioService, GrupoAcessoPermissaoService grupoAcessoPermissaoService)
        {
            _grupoAcessoPermissaoService = grupoAcessoPermissaoService;
            _grupoAcessoUsuarioService = grupoAcessoUsuarioService;
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

                        Session["UsuarioLogado"] = usuario;


                        if (Session["UsuarioLogado"] == null)
                            return View(u);
                        //return ((MVC.Models.UsuarioModelView)Session["UsuarioLogado"]). == Perfil.Adminstrador;

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
            try
            {
                var usuarioSessionLogado = (Usuario)Session["UsuarioLogado"];
                var grupo = _grupoAcessoUsuarioService.ListaGrupoAcessoPorUsuarioCollection(usuarioSessionLogado.Id);
                var a = (grupo.FirstOrDefault(u => u.GrupoAcesso.Perfil == Perfil.Adminstrador));
                if (Session["usuarioLogado"] != null && a.GrupoAcesso.Perfil == Perfil.Adminstrador)
                    return RedirectToAction("Index", "Home");

                throw new Exception("Algo errado não está certo");
            }
            catch (Exception e)
            {
                ViewBag.Erro = e.Message;
                return RedirectToAction("Login");
            }
        }
    }
}
