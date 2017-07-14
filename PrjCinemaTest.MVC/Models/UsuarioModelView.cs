using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PrjCinema.Domain.Entities;
using PrjCinema.Domain.Entities.Permissoes;


namespace PrjCinema.MVC.Models
{
    public class UsuarioModelView
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "É necessario ter um Nome preenchido.")]
        [MaxLength(150, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres")]
        [DisplayName("Nome")]
        public string Nome { get; set; }
        [Required, EmailAddress(ErrorMessage = "É necessário um email válido.")]
        [MaxLength(150, ErrorMessage = "Máximo de {0} caracteres")]
        [DisplayName("E-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "É necessario ter um CPF válido preenchido.")]
        [MaxLength(15, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(13, ErrorMessage = "Mínimo de {0} caracteres")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //public int EnderecoId { get; set; }
        //public virtual EnderecoModelView Endereco { get; set; }
        
        [Required]
        public string Telefone { get; set; }
        [Required]
        [DisplayName("Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        public Genero Genero { get; set; }
        public virtual ICollection<GrupoAcesso> GrupoAcessos { get; set; }
    }
}