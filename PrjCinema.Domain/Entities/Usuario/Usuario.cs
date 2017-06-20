using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrjCinema.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
        public Genero Genero { get; set; }
        public Perfil Perfil { get; set; }

    }
}
