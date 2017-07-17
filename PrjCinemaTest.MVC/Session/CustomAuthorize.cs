using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using PrjCinema.Domain.Entities;
using PrjCinema.Service.Service;

namespace PrjCinema.MVC.Session
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthorize : AuthorizeAttribute
    {
        public string UserRole { get; set; }
        public string UserPermissions { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (HttpContext.Current.Session["UsuarioLogado"] == null)
            {
                throw new Exception("Você deve estár logado para acessar está área.");
            }

            var permUsuario = (Usuario)HttpContext.Current.Session["UsuarioLogado"];

            //-----verificar permissões------
            if (permUsuario.GrupoAcesso != null && permUsuario.GrupoAcesso.Any(u => u.Permissoes != null))
            {
                var grupos = permUsuario.GrupoAcesso;
                foreach (var g in grupos)
                {
                    var permissoes = g.Permissoes;
                    foreach (var p in permissoes)
                    {
                        var operacoes = p.Operacoes;
                        foreach (var o in operacoes)
                        {
                            string CurrentUserPermission = o.NomeOperacao;
                            if (!CurrentUserPermission.IsEmpty())
                            {
                                if (UserPermissions.Contains(CurrentUserPermission))
                                {
                                    return true;
                                }
                            }
                        }

                    }
                }
            }
            //------------------------------
            
            //-----verificar Perfil de de Grupo Acesso------
            if (permUsuario.GrupoAcesso != null && permUsuario.GrupoAcesso.Any(u => u.Removido == false))
            {
               
                foreach (var a in permUsuario.GrupoAcesso)
                {
                    if (!a.Removido) // ---------------LEMBRAR DE ARRUMAR E DIMINUIR CONDIÇÔES---------------
                    {
                        string CurrentUserRole = a.Perfil.ToString();
                        if (!CurrentUserRole.IsEmpty())
                        {
                            if (UserRole.Contains(CurrentUserRole))
                            {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
            return false;

        }
    }
}