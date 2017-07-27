using System.Collections.Generic;
using PrjCinema.Domain.Entities.Permissoes;

namespace PrjCinema.MVC.Models
{
    public class OperacaoModelView
    {
        public int Id { get; set; }
        public bool Removido { get; set; }
        public string NomeOperacao { get; set; }
        public virtual ICollection<PermissaoModelView> Permissoes { get; set; }
    }
}