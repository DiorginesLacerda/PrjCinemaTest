using System.Collections.Generic;
using PrjCinema.Domain.Entities.Permissoes;

namespace PrjCinema.MVC.Models
{
    public class PermissaoModelView
    {
        public int Id { get; set; }
        public bool Removido { get; set; }
        public virtual ICollection<Operacao> Operacoes { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<GrupoAcesso> GrupoAcessos { get; set; }
    }
}