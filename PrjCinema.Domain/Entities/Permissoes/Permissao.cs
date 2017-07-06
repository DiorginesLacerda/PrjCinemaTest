using System.Collections.Generic;

namespace PrjCinema.Domain.Entities.Permissoes
{
    public class Permissao
    {
        public int Id { get; set; }
        public ICollection<Operacao> Operacoes  { get; set; }
        public string Nome { get; set; }
        public ICollection<GrupoAcesso> GrupoAcessos { get; set; }
    }
}