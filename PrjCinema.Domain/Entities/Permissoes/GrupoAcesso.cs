using System.Collections.Generic;

namespace PrjCinema.Domain.Entities.Permissoes
{
    public class GrupoAcesso
    {
        public int GrupoAcessoId { get; set; }
        public string Nome { get; set; }
        public Perfil Perfil { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<Permissao> Permissoes { get; set; }
    }
}