using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PrjCinema.Domain.Entities;
using PrjCinema.Domain.Entities.Permissoes;

namespace PrjCinema.MVC.Models
{
    public class GrupoAcessoModelView
    {
        public int Id { get; set; }
        public bool Removido { get; set; }
        [Required(ErrorMessage = "Por favor insira um Nome do Grupo.")]
        public string Nome { get; set; }
        public Perfil Perfil { get; set; }
        public virtual IEnumerable<Usuario> Usuarios { get; set; }
        public virtual IEnumerable<Permissao> Permissoes { get; set; }
    }
}