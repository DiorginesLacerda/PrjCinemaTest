using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using PrjCinema.Domain.Entities;
using PrjCinema.Domain.Entities.Permissoes;
using PrjCinema.Domain.Interfaces.Service;
using PrjCinema.MVC.Models;
using PrjCinema.Service.Service;

namespace PrjCinema.MVC.Controllers
{
    public class ConfiguracaoGrupoUsuarioPermissaoController : Controller
    {
        private readonly IGrupoAcessoService _grupoAcessoService;
        private readonly IPermissaoService _permissaoService;
        private readonly IOperacaoService _operacaoService;
        private readonly IUsuarioService _usuarioService;
        private readonly ITelaService _telaService;
        private readonly UsuarioService __usuarioService;
        private readonly PermissaoService __permissaoService;
        public ConfiguracaoGrupoUsuarioPermissaoController(UsuarioService usuarioService, TelaService telaService, GrupoAcessoService grupoAcessoService, PermissaoService permissaoService, OperacaoService operacaoService)
        {
            __permissaoService = permissaoService;
            __usuarioService = usuarioService;
            _operacaoService = operacaoService;
            _telaService = telaService;
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
            return View(Mapper.Map<Permissao, PermissaoModelView>(_permissaoService.GetById(id)));
        }

        // GET: ConfiguracaoGrupoUsuarioPermissao/Create
        public ActionResult CreatePermissao()
        {
            ViewBag.Telas = Mapper.Map<IEnumerable<Tela>, ICollection<TelaModelView>>(_telaService.GetAll());
            ViewBag.Operacoes = Mapper.Map<IEnumerable<Operacao>, ICollection<OperacaoModelView>>(_operacaoService.GetAll());
            return View();
        }

        // POST: ConfiguracaoGrupoUsuarioPermissao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePermissao(PermissaoModelView permissaoModelView, int[] operacaoId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var permissao = Mapper.Map<PermissaoModelView, Permissao>(permissaoModelView);
                    foreach (var op in operacaoId)
                    {
                        permissao.Operacoes.Add(_operacaoService.GetById(op));
                    }
                    _permissaoService.Add(permissao);
                    return RedirectToAction("IndexPermissoes");
                }

                return RedirectToAction("CreatePermissao", permissaoModelView);

            }
            catch (Exception e)
            {
                ViewBag.Erro = e.Message;
                return View(permissaoModelView);
            }
        }

        // GET: Permissao/Edit/5
        public ActionResult EditPermissao(int id)
        {
            ViewBag.Telas = Mapper.Map<IEnumerable<Tela>, ICollection<TelaModelView>>(_telaService.GetAll());
            return View(Mapper.Map<Permissao, PermissaoModelView>(_permissaoService.GetById(id)));
        }

        // POST: Permissao/Edit/5
        [HttpPost]
        public ActionResult EditPermissao(PermissaoModelView permissao, int telaId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    permissao.Tela = _telaService.GetById(telaId);
                    permissao.TelaId = telaId;
                    _permissaoService.Update(Mapper.Map<PermissaoModelView, Permissao>(permissao));
                    return RedirectToAction("IndexPermissoes");
                }
                return RedirectToAction("EditPermissao", permissao);
            }
            catch (Exception e)
            {
                ViewBag.Erro = e.Message;
                return View(permissao);
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult AddOpercaoAPermissao(int id)
        {
            ViewBag.Operacoes = Mapper.Map<IEnumerable<Operacao>, ICollection<OperacaoModelView>>(_operacaoService.GetAll());
            return View(Mapper.Map<Permissao, PermissaoModelView>(_permissaoService.GetById(id)));
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult AddOpercaoAPermissao(PermissaoModelView permissao, int operacaoId)
        {
            var getPermissaoComObjCorreto = _permissaoService.GetById(permissao.Id);
            try
            {
                if (ModelState.IsValid)
                {
                    getPermissaoComObjCorreto.Operacoes.Add(_operacaoService.GetById(operacaoId));
                    _permissaoService.Update(getPermissaoComObjCorreto);
                    return RedirectToAction("IndexPermissoes");
                }
                return RedirectToAction("CreateGrupoAcesso");
            }
            catch (Exception E)
            {
                ViewBag.Erro = E.Message;
                ViewBag.Operacoes = _operacaoService.GetAll();
                return View(Mapper.Map<Permissao, PermissaoModelView>(getPermissaoComObjCorreto));
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
        public ActionResult AddPermissaoAoGrupoAcesso(GrupoAcessoModelView grupoAcesso, int permissaoId)
        {
            var getGrupoAcessoComObjCorreto = _grupoAcessoService.GetById(grupoAcesso.Id);
            try
            {
                if (!ModelState.IsValid)
                {

                    var idVindoDoViewBagDaPermissao = _permissaoService.GetById(permissaoId);
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
        public ActionResult AddUsuarioAoGrupoAcesso(GrupoAcessoModelView grupoAcesso, int usuarioId)
        {
            var getGrupoAcessoComObjCorreto = _grupoAcessoService.GetById(grupoAcesso.Id);
            try
            {
                if (!ModelState.IsValid)
                {

                    var idVindoDoViewBagDaUsuario = _usuarioService.GetById(usuarioId);
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
            //ViewBag.Usuarios = __usuarioService.BuscaUsuariosPorGrupoAcesso(id);
            //ViewBag.Permissoes = __permissaoService.BuscaPermissoesPorGrupoAcesso(id);
            return View(Mapper.Map<GrupoAcesso, GrupoAcessoModelView>(_grupoAcessoService.GetById(id)));
        }

        // GET: ConfiguracaoGrupoUsuarioPermissao/Create
        public ActionResult CreateGrupoAcesso()
        {
            ViewBag.Permissoes = _permissaoService.GetAll();
            return View();
        }

        // POST: ConfiguracaoGrupoUsuarioPermissao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGrupoAcesso(GrupoAcessoModelView grupoAcesso, int permissoesId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var grupo = Mapper.Map<GrupoAcessoModelView, GrupoAcesso>(grupoAcesso);
                    grupo.Permissoes.Add(_permissaoService.GetById(permissoesId));
                    _grupoAcessoService.Add(grupo);
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
            ViewBag.Permissoes = _permissaoService.GetAll();
            return View(Mapper.Map<GrupoAcesso, GrupoAcessoModelView>(_grupoAcessoService.GetById(1)));
        }

        // POST: ConfiguracaoGrupoUsuarioPermissao/Edit/5
        [HttpPost]
        public ActionResult EditGrupoAcesso(GrupoAcessoModelView grupoAcesso, int permissoesId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var grupo = Mapper.Map<GrupoAcessoModelView, GrupoAcesso>(grupoAcesso);
                    grupo.Permissoes.Add(_permissaoService.GetById(permissoesId));
                    _grupoAcessoService.Update(grupo);
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
