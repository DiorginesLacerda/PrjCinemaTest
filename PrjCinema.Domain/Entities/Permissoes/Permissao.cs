using System.Collections.Generic;

namespace PrjCinema.Domain.Entities.Permissoes
{
    public class Permissao
    {
        public int PermissaoId { get; set; }
        public IEnumerable<Operacao> Operacoes  { get; set; }
        public string Nome { get; set; }
    }
}