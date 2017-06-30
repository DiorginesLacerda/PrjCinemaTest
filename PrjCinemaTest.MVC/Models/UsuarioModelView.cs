using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PrjCinema.Domain.Entities;

namespace PrjCinema.MVC.Models
{
    public class UsuarioModelView
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "É necessario ter um Nome preenchido")]
        [MaxLength(150, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres")]
        [DisplayName("Nome")]
        public string Nome { get; set; }
        [Required, EmailAddress(ErrorMessage = "É necessário um email válido")]
        [MaxLength(150, ErrorMessage = "Máximo de {0} caracteres")]
        [DisplayName("E-mail")]
        public string Email { get; set; }
        [Required]
        [MaxLength(15, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(13, ErrorMessage = "Mínimo de {0} caracteres")]
        public string Cpf { get; set; }
        [DisplayName("Endereço")]
        public int EnderecoId { get; set; }
        [Required]
        public virtual EnderecoModelView Endereco { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        [DisplayName("Data de Cadastro")]
        public DateTime DataCadastro { get; set; }
        [Required]
        public Genero Genero { get; set; }
        public Perfil Perfil { get; set; }
    }
}