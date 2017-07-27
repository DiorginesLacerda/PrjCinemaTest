using System.Collections.Generic;
using PrjCinema.Domain.Entities.Permissoes;

namespace PrjCinema.MVC.Models
{
    public class TelaModelView
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Removido { get; set; }
        public virtual ICollection<Permissao> Permissoes { get; set; }
    }
}