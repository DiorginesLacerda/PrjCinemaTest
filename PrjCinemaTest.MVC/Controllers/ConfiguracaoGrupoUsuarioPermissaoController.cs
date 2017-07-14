using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.WebPages;
using AutoMapper;
using PrjCinema.Domain.Entities;
using PrjCinema.Domain.Entities.Permissoes;
using PrjCinema.Domain.Entities.SerieFilme;
using PrjCinema.Domain.Interfaces.Service;
using PrjCinema.MVC.Models;
using PrjCinema.Service.Service;

namespace PrjCinema.MVC.Controllers
{
    public class ConfiguracaoGrupoUsuarioPermissaoController : Controller
    {
        private readonly IGrupoAcessoService _grupoAcessoService;
        private readonly IPermissaoService _permissaoService;
        private readonly IUsuarioService _usuarioService;
        public ConfiguracaoGrupoUsuarioPermissaoController(UsuarioService usuarioService, GrupoAcessoService grupoAcessoService, PermissaoService permissaoService)
        {
            _usuarioService = usuarioService;
            _grupoAcessoService = grupoAcessoService;
            _permissaoService = permissaoService;
        }

        //-------------------------------Permissões------------------------------------------

        //GET: ConfiguracaoGrupoUsuarioPermissao
        public ActionResult IndexPermissoes()
        {
            return View(Mapper.Map<IEnumerable<Permissao>, IEnumerable<PermissaoModelView>>(_permissaoService.GetAll()));
        }

        // GET: ConfiguracaoGrupoUsuarioPermissao/Details/5
        public ActionResult DetailsPermissao(int id)
        {
            return View(Mapper.Map<Permissao, PermissaoModelView>(_permissaoService.GetById(1)));
        }

        // GET: ConfiguracaoGrupoUsuarioPermissao/Create
        public ActionResult CreatePermissao()
        {
            return View();
        }

        // POST: ConfiguracaoGrupoUsuarioPermissao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePermissao(PermissaoModelView permissao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _permissaoService.Add(Mapper.Map<PermissaoModelView, Permissao>(permissao));
                    return RedirectToAction("IndexPermissoes");
                }

                return RedirectToAction("CreatePermissao", permissao);

            }
            catch (Exception e)
            {
                ViewBag.Erro = e.Message;
                return View(permissao);
            }
        }

        //-------------------------------Grupo de Acesso------------------------------------------

            public ActionResult IndexGrupoAcessos()
        {
            return View(Mapper.Map<IEnumerable<GrupoAcesso>, IEnumerable<GrupoAcessoModelView>>(_grupoAcessoService.GetAll()));
        }
        
        // GET: Usuario/Edit/5
        public ActionResult AddPermissaoAoGrupoAcesso(int id)
        {
            ViewBag.Permissoes = Mapper.Map<IEnumerable<Permissao>, ICollection<PermissaoModelView>>(_permissaoService.GetAll());
            return View(Mapper.Map<GrupoAcesso, GrupoAcessoModelView>(_grupoAcessoService.GetById(id)));
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult AddPermissaoAoGrupoAcesso(GrupoAcessoModelView grupoAcesso, string permissaoId)
        {
            var getGrupoAcessoComObjCorreto = _grupoAcessoService.GetById(grupoAcesso.Id);
            try
            {
                if (!ModelState.IsValid)
                {

                    var idVindoDoViewBagDaPermissao = _permissaoService.GetById(permissaoId.AsInt());
                    getGrupoAcessoComObjCorreto.Permissoes.Add(idVindoDoViewBagDaPermissao);
                    _grupoAcessoService.Update(getGrupoAcessoComObjCorreto);
                    return RedirectToAction("IndexGrupoAcessos");
                }
                return RedirectToAction("CreateGrupoAcesso");
            }
            catch (Exception E)
            {
                ViewBag.Erro = E.Message;
                ViewBag.Usuarios = Mapper.Map<ICollection<Usuario>, ICollection<UsuarioModelView>>(_usuarioService.GetAll());
                return View(Mapper.Map<GrupoAcesso, GrupoAcessoModelView>(getGrupoAcessoComObjCorreto));
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult AddUsuarioAoGrupoAcesso(int id)
        {
            ViewBag.Usuarios = Mapper.Map<IEnumerable<Usuario>, ICollection<UsuarioModelView>>(_usuarioService.GetAll());
            return View(Mapper.Map<GrupoAcesso, GrupoAcessoModelView>(_grupoAcessoService.GetById(id)));
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult AddUsuarioAoGrupoAcesso(GrupoAcessoModelView grupoAcesso, string usuarioId)
        {
            var getGrupoAcessoComObjCorreto = _grupoAcessoService.GetById(grupoAcesso.Id);
            try
            {
                if (!ModelState.IsValid)
                {

                    var idVindoDoViewBagDaUsuario = _usuarioService.GetById(usuarioId.AsInt());
                    getGrupoAcessoComObjCorreto.Usuarios.Add(idVindoDoViewBagDaUsuario);
                    _grupoAcessoService.Update(getGrupoAcessoComObjCorreto);
                    return RedirectToAction("IndexGrupoAcessos");
                }
                return RedirectToAction("CreateGrupoAcesso");
            }
            catch (Exception E)
            {
                ViewBag.Erro = E.Message;
                ViewBag.Usuarioes = Mapper.Map<ICollection<Usuario>, ICollection<UsuarioModelView>>(_usuarioService.GetAll());
                return View(Mapper.Map<GrupoAcesso, GrupoAcessoModelView>(getGrupoAcessoComObjCorreto));
            }
        }

        // GET: ConfiguracaoGrupoUsuarioPermissao/Details/5
        public ActionResult DetailsGrupoAcesso(int id)
        {
            return View(Mapper.Map<GrupoAcesso, GrupoAcessoModelView>(_grupoAcessoService.GetById(1)));
        }

        // GET: ConfiguracaoGrupoUsuarioPermissao/Create
        public ActionResult CreateGrupoAcesso()
        {
            return View();
        }

        // POST: ConfiguracaoGrupoUsuarioPermissao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGrupoAcesso(GrupoAcessoModelView grupoAcesso)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _grupoAcessoService.Add(Mapper.Map<GrupoAcessoModelView, GrupoAcesso>(grupoAcesso));
                    return RedirectToAction("IndexGrupoAcessos");
                }

                return RedirectToAction("CreateGrupoAcesso", grupoAcesso);

            }
            catch (Exception e)
            {
                ViewBag.Erro = e.Message;
                return View(grupoAcesso);
            }
        }


        // GET: ConfiguracaoGrupoUsuarioPermissao/Edit/5
        public ActionResult EditGrupoAcesso(int id)
        {
            return View(Mapper.Map<GrupoAcesso, GrupoAcessoModelView>(_grupoAcessoService.GetById(1)));
        }

        // POST: ConfiguracaoGrupoUsuarioPermissao/Edit/5
        [HttpPost]
        public ActionResult EditGrupoAcesso(GrupoAcessoModelView grupoAcesso)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _grupoAcessoService.Update(Mapper.Map<GrupoAcessoModelView, GrupoAcesso>(grupoAcesso));
                    return RedirectToAction("IndexGrupoAcessos");
                }

                return RedirectToAction("EditGrupoAcesso", grupoAcesso);
            }
            catch (Exception e)
            {
                ViewBag.Erro = e.Message;
                return View(grupoAcesso);
            }
        }
    }

    
}
    

    //// GET: ConfiguracaoGrupoUsuarioPermissao/Delete/5
    //public ActionResult Delete(int id)
    //{
    //    return View();
    //}

    //// POST: ConfiguracaoGrupoUsuarioPermissao/Delete/5
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
