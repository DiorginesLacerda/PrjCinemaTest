using System.Collections.Generic;
using PrjCinema.Domain.Entities.Relacoes;

namespace PrjCinema.Domain.Entities.Permissoes
{
    public class Permissao
    {
        public int Id { get; set; }
        public IEnumerable<Operacao> Operacoes  { get; set; }
        public string Nome { get; set; }
        public IEnumerable<GrupoAcessoPermissao> GrupoAcessosAcessoPermissoes { get; set; }
    }
}