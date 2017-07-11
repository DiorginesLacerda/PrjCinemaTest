using System.Collections.Generic;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Domain.Entities.Permissoes
{
    public class GrupoAcesso: ITEntity
    {
        public int Id { get; set; }
        public bool Removido { get; set; }
        public string Nome { get; set; }
        public Perfil Perfil { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<Permissao> Permissoes { get; set; }

        public object Clone()
        {
            throw new System.NotImplementedException();
        }
    }
}