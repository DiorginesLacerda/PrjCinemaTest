using System.Collections.Generic;
using System.Linq;
using PrjCinema.Data.Repositories.ContextFactory;
using PrjCinema.Domain.Entities;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {

        public UsuarioRepository(IContextFactory dbContextFactory)
             : base (dbContextFactory)
        {
            
        }
        //public void Add(Usuario obj)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}

        //public ICollection<Usuario> GetAll()
        //{
        //    return GetAll();
        //}

        //public Usuario GetById(int id)
        //{
        //    return GetById(id);
        //}

        //public void Remove(Usuario obj)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Update(Usuario obj)
        //{
        //    throw new NotImplementedException();
        //}
        public IEnumerable<Usuario> UsuariosAtivos()
        {
            return GetAll().Where(x => x.Removido != true);
        }
    }
}
