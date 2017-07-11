using System.Collections.Generic;

using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Domain.Entities.Permissoes
{
    public class Permissao : ITEntity
    {
        public int Id { get; set; }
        public bool Removido { get; set; }
        public ICollection<Operacao> Operacoes  { get; set; }
        public string Nome { get; set; }
        public ICollection<GrupoAcesso> GrupoAcesso{ get; set; }

        public object Clone()
        {
            throw new System.NotImplementedException();
        }
    }
}