﻿using PrjCinema.Domain.Entities.Permissoes;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Data.Repositories
{
    public class PermissaoRepository : RepositoryBase<Permissao>, IPermissaoRepository
    {

        //public ICollection<Permissao> GetApartirUsuario(int idUsuario)
        //{
        //    //return (from grupoAcesso in context.GrupoAcessos
        //    //                                   .Include(x=> x.GrupoAcessoPermissoes.Select(u=>u.Permissao))
        //    //                                   .Include(x=>x.GrupoAcessoUsuarios.Select(u=>u.Usuario))
        //    //        where grupoAcesso.GrupoAcessoUsuarios.Any(u=>u.Usuario.Id == idUsuario)
        //    //        select grupoAcesso.GrupoAcessoPermissoes.FirstOrDefault().Permissao);

        //    var a = (from grpAcesso in context.GrupoAcessos
        //        join grpPermissoes in context.GrupoAcessoPermissoes on grpAcesso.Id equals grpPermissoes.GrupoAcessoId
        //        from grpUsuario in context.GrupoAcessoUsuarios
        //        where grpAcesso.Id == grpUsuario.GrupoAcessoId
        //        select grpPermissoes);


        //    //from grpPermissoes in context.GrupoAcessoPermissoes 

        //}
    }
}
