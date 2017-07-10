using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PrjCinema.Domain.Entities.Relacoes;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Data.Repositories
{
    public class GrupoAcessoUsuarioRepository : RepositoryBase<GrupoAcessoUsuario>, IGrupoAcessoUsuarioRepository
    {

        public IEnumerable<GrupoAcessoUsuario> BuscaGrupoPorUsuario(int id)
        {
            return GetAll().Where(u => u.UsuarioId == id);
        }

        public IEnumerable<GrupoAcessoUsuario> BuscaUsuarioPorGrupo(int id)
        {
            return GetAll().Where(u => u.GrupoAcessoId == id);
        }
        
        public IEnumerable<GrupoAcessoUsuario> ListaGrupoPorUsuario(int id)
        {
            return context.GrupoAcessoUsuarios.Include(u => u.GrupoAcesso).Include(u => u.Usuario).Where(u => u.UsuarioId == id);
        }

        public IEnumerable<GrupoAcessoUsuario> ListaUsuarioPorGrupo(int id)
        {
            return context.GrupoAcessoUsuarios.Include(u => u.Usuario).Include(u => u.GrupoAcesso).Where(u => u.GrupoAcessoId == id);
        }


        public ICollection<GrupoAcessoUsuario> ListaGrupoAcessoPorUsuarioCollection(int id)
        {
            ICollection<GrupoAcessoUsuario> a = new List<GrupoAcessoUsuario>();
            a = new List<GrupoAcessoUsuario>(BuscaGrupoPorUsuario(id));
            return  a;
        }
    }
}