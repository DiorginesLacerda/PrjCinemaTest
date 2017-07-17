using System;
using System.Web.Mvc;
using PrjCinema.Domain.Entities;
using PrjCinema.Domain.Entities.Permissoes;
using PrjCinema.MVC.Models;
using PrjCinema.Service.Service;

namespace PrjCinema.MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly OperacaoService _operacaoService;
        private readonly UsuarioService _usuarioService;
        public LoginController(UsuarioService usuarioService, OperacaoService operacaoService)
        {
            _operacaoService = operacaoService;
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
                    if (usuario != null && !usuario.Removido)
                    {
                        Session["UsuarioLogado"] = usuario;
                        if (Session["UsuarioLogado"] == null)
                            return View(u);
                        return RedirectToAction("Index");
                    }
                    throw new Exception("Está conta não existe ou não está ativa, por favor contate seu Gerente ou Adminstrador da Rede.");
                }
                return View(u);
            }
            catch (Exception e)
            {
                ViewBag.Erro = e.Message;
                return View(u);
            }
        }

        public ActionResult Logout()
        {
            var use = (Usuario)Session["UsuarioLogado"];
            try
            {
                if (use != null)
                {
                    Session.Remove("UsuarioLogado");
                    return RedirectToAction("Login");
                }
                throw new Exception("Você tem que estar logado para poder se deslogar");
            }
            catch (Exception e)
            {
                ViewBag.Erro = e.Message;
                return RedirectToAction("Login");
            }
        }

        public ActionResult Index()
        {
            try
            {
                var usuarioSessionLogado = (Usuario)Session["UsuarioLogado"];
                //var grupo = _grupoAcessoUsuarioService.ListaGrupoAcessoPorUsuarioCollection(usuarioSessionLogado.Id);
                //var a = grupo.FirstOrDefault(u => u.GrupoAcesso.Perfil >= 0);
                if (usuarioSessionLogado == null)
                    throw new Exception("Algo errado não está certo");

                if (Session["usuarioLogado"] != null /*&& a.GrupoAcesso.Perfil >= 0*/)
                {

                    return RedirectToAction("Index", "Home");
                }
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
