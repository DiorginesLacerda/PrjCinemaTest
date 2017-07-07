using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PrjCinema.Domain.Entities.Relacoes;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Data.Repositories
{
    public class GrupoAcessoPermissaoRepository : RepositoryBase<GrupoAcessoPermissao>, IGrupoAcessoPermissaoRepository
    {

        public IEnumerable<GrupoAcessoPermissao> BuscaGrupoPorPermissao(int id)
        {
            return GetAll().Where(u => u.PermissaoId == id);
        }


        public IEnumerable<GrupoAcessoPermissao> BuscaPermissaoPorGrupo(int id)
        {
            return GetAll().Where(u => u.GrupoAcessoId == id);
        }
        
        public IEnumerable<GrupoAcessoPermissao> ListaGrupoPorPermissao(int id)
        {
            return context.GrupoAcessoPermissoes.Include(u => u.GrupoAcesso).Include(u => u.Permissao).Where(u => u.PermissaoId == id);
        }

        public IEnumerable<GrupoAcessoPermissao> ListaPermissaoPorGrupo(int id)
        {
            return context.GrupoAcessoPermissoes.Include(u => u.Permissao).Include(u => u.GrupoAcesso).Where(u => u.GrupoAcessoId == id);
        }
    }
}