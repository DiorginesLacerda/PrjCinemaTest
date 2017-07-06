﻿using System;
using System.Collections.Generic;
using PrjCinema.Domain.Entities.Permissoes;

namespace PrjCinema.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Password { get; set; }
     //   public int EnderecoId { get; set; }
    //    public virtual Endereco Endereco { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
        public Genero Genero { get; set; }
        public Perfil Perfil { get; set; }
        public virtual ICollection<GrupoAcesso> GrupoAcesso { get; set; }
    }
}
