﻿using PrjCinema.Domain.Entities.Permissoes;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Data.Repositories
{
    public class GrupoAcessoRepository : RepositoryBase<GrupoAcesso>, IGrupoAcessoRepository
    {
        //public ICollection<GrupoAcesso> ListaPermissoesPorUsuarioDoGrupo(int id)
        //{
        //    var x = context.GrupoAcessoPermissoes.Include(u=> u.GrupoAcesso).Where(u => u.GrupoAcessoId == id);
            
        //    return context.GrupoAcessos.Include(u => u.GrupoAcessoUsuarios).Include(u => u.GrupoAcessoPermissoes)
        //        .Where(u => u.Id == id);
        //}
    }
}