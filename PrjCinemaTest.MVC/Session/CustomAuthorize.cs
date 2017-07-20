using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using PrjCinema.Domain.Entities;

namespace PrjCinema.MVC.Session
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthorize : AuthorizeAttribute
    {
        public string UserRole { get; set; }
        public string UserPermissions { get; set; }
        public string UserTelaPermissions { get; set; }
        
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (HttpContext.Current.Session["UsuarioLogado"] == null)
            {
                return false;
            }
            var permUsuario = (Usuario)HttpContext.Current.Session["UsuarioLogado"];

            if (!UserRole.IsEmpty() && IsVerificaPerfilDeGrupo(permUsuario))
            {
                return true;
            }
            if (!UserTelaPermissions.IsEmpty() && IsVerificaPermissaoDeOperacaoPorTela(permUsuario))
            {
                return true;
            }
            if (!UserPermissions.IsEmpty() && IsVerificaPermissoes(permUsuario))
            {
                return true;
            }

            return false;

        }

        //-----verificar Perfil de de Grupo Acesso------
        private bool IsVerificaPerfilDeGrupo(Usuario permUsuario)
        {
            if (permUsuario.GrupoAcesso != null && permUsuario.GrupoAcesso.Any(u => u.Removido == false))
            {

                foreach (var a in permUsuario.GrupoAcesso)
                {
                    if (!a.Removido) // ---------------LEMBRAR DE ARRUMAR E DIMINUIR CONDIÇÔES---------------
                    {
                        string CurrentUserRole = a.Perfil.ToString();
                        if (!CurrentUserRole.IsEmpty())
                        {
                            string[] roles = UserRole.Split(',');
                            if (roles.Contains(CurrentUserRole))
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

        //-----verificar permissões------
        private bool IsVerificaPermissoes(Usuario permUsuario)
        {
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
                                string[] permissions = UserPermissions.Split(',');
                                if (UserPermissions.IsEmpty())
                                {
                                    return true;
                                }
                                if (permissions.Contains(CurrentUserPermission))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }


        //-------verificar permissão de Operação por Tela ----------
        // Permissão de tela deve sempre vir primeiro da permissão de operação na anotação da controller para validar corretamente nesta condição
        private bool IsVerificaPermissaoDeOperacaoPorTela(Usuario permUsuario)
        {
            string[] permissions = UserTelaPermissions.Split(',');
            string tela = permissions[0];
            string[] operacoesTela = { "" };
            List<string> operacoes = new List<string>();
            int operacoesIguais = 0;
            
            for (int i = 1; i < permissions.Length; i++)
            {
                operacoesTela[i - 1] = permissions[i];
            }
            var grupoAcesso = permUsuario.GrupoAcesso.FirstOrDefault(u => u.Permissoes.
                Any(y => y.Tela.Nome == tela));
            var permissao = grupoAcesso.Permissoes.First(y => y.Tela.Nome == tela);
            foreach (var op in permissao.Operacoes)
            {
                if (!op.Removido)
                {
                    operacoes.Add(op.NomeOperacao);
                }
            }
            for (int j = 0; j < operacoesTela.Length; j++)
            {
                for (int i = 0; i < operacoes.Count; i++)
                {
                    if (operacoesTela[j] == operacoes[i])
                    {
                        operacoesIguais++;
                    }
                }
            }
            if (operacoesIguais == operacoesTela.Length)
            {
                return true;
            }

            return false;
        }
    }
}