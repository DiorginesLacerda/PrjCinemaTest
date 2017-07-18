using System.Collections.Generic;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Domain.Entities.Permissoes
{
    public class Tela : ITEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Removido { get; set; }
        public virtual ICollection<Permissao> Permissoes { get; set; }

        public object Clone()
        {
            throw new System.NotImplementedException();
        }
    }
}