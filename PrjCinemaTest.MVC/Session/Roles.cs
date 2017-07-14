using System;
using System.Web;
using System.Web.Security;
using PrjCinema.Domain.Entities;
using PrjCinema.Service.Service;

namespace PrjCinema.MVC.Session
{
    public class Roles : RoleProvider
    {
        private readonly UsuarioService _usuarioService;
        private readonly GrupoAcessoService _grupoAcessoService;

        public Roles(UsuarioService usuarioService,GrupoAcessoService grupoAcessoService)
        {
            _grupoAcessoService = grupoAcessoService;
            _usuarioService = usuarioService;
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            var usu = (Usuario) HttpContext.Current.Session["UsuarioLogado"];
            // (Usuario)Session["UsuarioLogado"];
            //string[] retorno = {null };
            //return retorno;

            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}