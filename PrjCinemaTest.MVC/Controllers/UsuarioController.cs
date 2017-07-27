using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using PrjCinema.Domain.Entities;
using PrjCinema.Domain.Entities.Permissoes;
using PrjCinema.Domain.Interfaces.Service;
using PrjCinema.MVC.Models;
using PrjCinema.MVC.Session;
using PrjCinema.MVC.Util;
using PrjCinema.Service.Service;

namespace PrjCinema.MVC.Controllers
{
    [CustomAuthorize(UserRole = "Administrador,Gerente")]
    [TelaAuthorize(UserTelaPermission = "Usuario")]
    public class UsuarioController : Controller
    {
        private readonly IPermissaoService _permissaoService;
        private readonly IGrupoAcessoService _grupoAcessoService;
        private readonly IUsuarioService _usuarioService;
        private readonly UsuarioService __usuarioService;
        public UsuarioController(UsuarioService usuarioService, GrupoAcessoService grupoAcessoService, PermissaoService permissaoService)
        {
            _permissaoService = permissaoService;
            _grupoAcessoService = grupoAcessoService;
            __usuarioService = usuarioService;
            _usuarioService = usuarioService;
        }
        [CustomAuthorize(UserTelaPermissions = "Usuario,Visualizar")]
        // GET: Usuario
        public ActionResult Index()
        {

            if (ULogin.IsAdmin("Administrador"))
            {
                return View(Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioModelView>>(_usuarioService.GetAll()));

            }
            return View(Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioModelView>>(_usuarioService.UsuariosAtivos()));
        }

        [CustomAuthorize(UserTelaPermissions = "Usuario,Visualizar")]
        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View(Mapper.Map<Usuario, UsuarioModelView>(_usuarioService.GetById(id)));
        }

        [CustomAuthorize(UserTelaPermissions = "Usuario,Visualizar")]
        //POST:  Usuario/ListaDeGrupos/1
        public ActionResult ListaDeGrupos(int id)
        {
            ViewBag.Usuario = _usuarioService.GetById(id).Nome;
            return View(Mapper.Map<IEnumerable<GrupoAcesso>, IEnumerable<GrupoAcessoModelView>>(_usuarioService.GetById(id).GrupoAcesso));
        }

        public ActionResult DetalhesGrupoAcesso(int id)
        {
            try
            {
                return RedirectToAction("DetailsGrupoAcesso", "ConfiguracaoGrupoUsuarioPermissao", id);


            }
            catch (Exception e)
            {
                ViewBag.Erro = e.Message;
                return RedirectToAction("Index");
            }

        }
        [CustomAuthorize(UserTelaPermissions = "Usuario,Criar Conta")]
        // GET: Usuario/Create
        public ActionResult Create()
        {
            return PartialView("Partials/_UsuarioCreate");
        }

        [CustomAuthorize(UserTelaPermissions = "Usuario,Criar Conta")]
        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioModelView usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuario.Removido = true;
                    __usuarioService.AddUsuario(Mapper.Map<UsuarioModelView, Usuario>(usuario));
                    TempData["success"] = "Novo usuário criado com sucesso!!";
                    return PartialView("Partials/_UsuarioCreate");
                }
                throw new Exception("Não foi possivel editar este usuário, por favor contate o administrador do sistema.");

            }
            catch (Exception e)
            {
                TempData["warning"] = e.Message;
                return RedirectToAction("Create", usuario);
            }


        }
        [CustomAuthorize(UserTelaPermissions = "Usuario,Editar")]
        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Mapper.Map<Usuario, UsuarioModelView>(_usuarioService.GetById(id)));
        }

        [CustomAuthorize(UserTelaPermissions = "Usuario,Editar")]
        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(UsuarioModelView usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["success"] = "Usuário editado com sucesso!!";
                    _usuarioService.Update(Mapper.Map<UsuarioModelView, Usuario>(usuario));
                    return RedirectToAction("Index");
                }

                throw new Exception("Não foi possivel editar este usuário, por favor contate o administrador do sistema.");
            }
            catch (Exception e)
            {
                TempData["warning"] = e.Message;
                return View(usuario);
            }
        }
        [CustomAuthorize(UserTelaPermissions = "Usuario,Remover")]
        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                if (ValidateRequest)
                {
                    TempData["success"] = "Usuário removido com sucesso!!";
                    __usuarioService.Desativar(_usuarioService.GetById(id));
                    return RedirectToAction("Index");
                }

                throw new Exception("Não foi possivel remover este usuário, por favor contate o administrador do sistema.");

            }
            catch (Exception e)
            {
                TempData["warning"] = e.Message;
                return RedirectToAction("Index");
            }

        }

        // GET: Usuario/Delete/5
        [CustomAuthorize(UserTelaPermissions = "Usuario,Remover")]
        public ActionResult Ativar(int id)
        {
            try
            {
                if (ValidateRequest)
                {
                    if (ULogin.IsAdmin("Administrador"))
                    {
                        TempData["success"] = "Usuário foi ativado com sucesso!!";
                        __usuarioService.Ativar(_usuarioService.GetById(id));
                        return RedirectToAction("Index");
                    }
                }
                throw new Exception("Não foi possivel ativar este usuário, por favor contate o administrador do sistema.");

            }
            catch (Exception e)
            {
                TempData["warning"] = e.Message;
                return RedirectToAction("Index");
            }

        }





        //------------------------- Action com JSON --------------------------


        public ActionResult IndexTest()
        {
            return View();
        }

        public JsonResult listaUsuario()
        {
            return Json(new { data = Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioModelView>>(_usuarioService.GetAll()) }, JsonRequestBehavior.AllowGet);
        }
        [AllowAnonymous]
        public JsonResult listaUsuario2()
        {
            List<UsuarioModelView> user = new List<UsuarioModelView>();
            var u = _usuarioService.GetAll();
            foreach (var us in u)
            {
                var usuario = Mapper.Map<Usuario, UsuarioModelView>(us);
                usuario.GrupoAcesso =
                    Mapper.Map<IEnumerable<GrupoAcesso>, IEnumerable<GrupoAcessoModelView>>(us.GrupoAcesso);

                user.Add(usuario);
            }
            
          
             

            var obsRetorno = u.Select(i=> new {i.Id, i.Nome, i.Removido, i.Email, i.DataCadastro,
                   GrupoLista = i.GrupoAcesso.Select(g=> new { g.Nome, g.Perfil,
                       PermicoesLista = g.Permissoes.Select(p=> new {p.Nome,
                           OperacoesLista = p.Operacoes.Select(o=> new {o.NomeOperacao})} ) })
                }
            );
           



            return Json(new { data = obsRetorno, dataMapper = user }, JsonRequestBehavior.AllowGet);
        }
    }
}
