using System;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using PrjCinema.Domain.Entities;

namespace PrjCinema.MVC.Session
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class TelaAuthorize : AuthorizeAttribute
    {
        public string UserTelaPermission { get; set; }
        public string User { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (HttpContext.Current.Session["UsuarioLogado"] == null)
            {
                return false;
            }

            var permUsuario = (Usuario)HttpContext.Current.Session["UsuarioLogado"];
            //-----verificar permissão de Tela --------

            if (permUsuario.GrupoAcesso != null && permUsuario.GrupoAcesso.Any(u => u.Permissoes != null))
            {
                var grupos = permUsuario.GrupoAcesso;
                foreach (var g in grupos)
                {
                    var permissoes = g.Permissoes;
                    foreach (var p in permissoes)
                    {
                        var CurrentUserPermission = p.Tela.Nome;
                        if (UserTelaPermission.IsEmpty())
                        {
                            return true;
                        }
                        if (UserTelaPermission.Contains(CurrentUserPermission))
                        {
                            return true;
                        }
                    }
                }
            }
            //------------------------------
            return false;
        }




    }
}