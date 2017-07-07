using System.Collections.Generic;
using PrjCinema.Domain.Entities.Relacoes;

namespace PrjCinema.Domain.Entities.Permissoes
{
    public class GrupoAcesso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Perfil Perfil { get; set; }
        public virtual IEnumerable<GrupoAcessoUsuario> GrupoAcessoUsuarios { get; set; }
        public virtual IEnumerable<GrupoAcessoPermissao> GrupoAcessoPermissoes { get; set; }
    }
}