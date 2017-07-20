using System.Linq;
using System.Web;
using System.Web.WebPages;
using PrjCinema.Domain.Entities;

namespace PrjCinema.MVC.Util
{
    public static class ULogin
    {
        static public bool IsNaRole(string role)
        {
            if (HttpContext.Current.Session["UsuarioLogado"] == null)
            {
                return false;
            }


            var permUsuario = (Usuario)HttpContext.Current.Session["UsuarioLogado"];

            if (permUsuario.GrupoAcesso.AsEnumerable()
                .Any(x => x.Permissoes
                    .Any(y => y.Operacoes
                        .Any(t => t.NomeOperacao.Contains(role) && !t.Removido))))
                return true;
            return false;
        }

        static public bool IsAdmin(string perfil)
        {
            if (HttpContext.Current.Session["UsuarioLogado"] == null)
            {
                return false;
            }


            var permUsuario = (Usuario)HttpContext.Current.Session["UsuarioLogado"];
            //-----verificar Perfil de de Grupo Acesso------
            if (permUsuario.GrupoAcesso != null && permUsuario.GrupoAcesso.Any(u => u.Removido == false))
            {

                foreach (var a in permUsuario.GrupoAcesso)
                {
                    if (!a.Removido && a.Perfil.ToString() == perfil) // ---------------LEMBRAR DE ARRUMAR E DIMINUIR CONDIÇÔES---------------
                    {
                       return true;
                    }
                }
                return false;
            }
            return false;
        }
    }
}