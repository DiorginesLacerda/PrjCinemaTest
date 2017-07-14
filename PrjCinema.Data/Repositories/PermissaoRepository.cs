using System;
using System.Collections.Generic;
using System.Linq;
using PrjCinema.Data.Repositories.ContextFactory;
using PrjCinema.Domain.Entities.Permissoes;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Data.Repositories
{
    public class PermissaoRepository :RepositoryBase<Permissao>, IPermissaoRepository
    {
        public PermissaoRepository(IContextFactory dbContextFactory)
            : base(dbContextFactory)
        {

        }
        public IEnumerable<Permissao> PermissoesPorUsuario(int id)
        {
            return GetAll().Where(u => u.GrupoAcesso.Any(x => x.Usuarios.Any(y => y.Id == id)));
        }

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

        public void Add(Permissao obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ICollection<Permissao> GetAll()
        {
            return GetAll();
        }

        public Permissao GetById(int id)
        {
            return GetById(id);
        }

        public void Remove(Permissao obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Permissao obj)
        {
            throw new NotImplementedException();
        }
    }
}
