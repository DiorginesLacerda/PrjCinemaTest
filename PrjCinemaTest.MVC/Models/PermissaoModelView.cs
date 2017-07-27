using System.Collections.Generic;
using PrjCinema.Domain.Entities.Permissoes;

namespace PrjCinema.MVC.Models
{
    public class PermissaoModelView
    {
        public int Id { get; set; }
        public bool Removido { get; set; }
        public virtual IEnumerable<OperacaoModelView> Operacoes { get; set; }
        public string Nome { get; set; }
        public int TelaId { get; set; }
        public virtual Tela Tela { get; set; }
        public virtual IEnumerable<GrupoAcessoModelView> GrupoAcessos { get; set; }
    }
}