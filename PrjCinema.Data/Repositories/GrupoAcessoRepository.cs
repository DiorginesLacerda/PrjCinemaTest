using PrjCinema.Data.Repositories.ContextFactory;
using PrjCinema.Domain.Entities.Permissoes;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Data.Repositories
{
    public class GrupoAcessoRepository : RepositoryBase<GrupoAcesso>,IGrupoAcessoRepository
    {
        public GrupoAcessoRepository(IContextFactory dbContextFactory)
            : base(dbContextFactory)
        {

        }
        //public ICollection<GrupoAcesso> ListaPermissoesPorUsuarioDoGrupo(int id)
        //{
        //    var x = context.GrupoAcessoPermissoes.Include(u=> u.GrupoAcesso).Where(u => u.GrupoAcessoId == id);

        //    return context.GrupoAcessos.Include(u => u.GrupoAcessoUsuarios).Include(u => u.GrupoAcessoPermissoes)
        //        .Where(u => u.Id == id);
        //}

        //public void Add(GrupoAcesso obj)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}

        //public ICollection<GrupoAcesso> GetAll()
        //{
        //    return GetAll();
        //}

        //public GrupoAcesso GetById(int id)
        //{
        //    return GetById(id);
        //}

        //public void Remove(GrupoAcesso obj)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Update(GrupoAcesso obj)
        //{
        //    throw new NotImplementedException();
        //}

    }
}