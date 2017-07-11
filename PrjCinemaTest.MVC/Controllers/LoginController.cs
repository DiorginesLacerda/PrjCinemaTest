﻿using System;
using System.Web.Mvc;
using PrjCinema.Domain.Entities;
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



                    if (usuario != null)
                    {
                        Session["UsuarioLogado"] = usuario;
                        if (Session["UsuarioLogado"] == null)
                            return View(u);
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
                //var grupo = _grupoAcessoUsuarioService.ListaGrupoAcessoPorUsuarioCollection(usuarioSessionLogado.Id);
                //var a = grupo.FirstOrDefault(u => u.GrupoAcesso.Perfil >= 0);
                if (usuarioSessionLogado != null)
                    throw new Exception("Algo errado não está certo");

                if (Session["usuarioLogado"] != null /*&& a.GrupoAcesso.Perfil >= 0*/)
                {
                    ViewBag.UsuarioLogin = usuarioSessionLogado.Email;
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
