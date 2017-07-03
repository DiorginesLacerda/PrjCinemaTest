using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PrjCinema.Domain.Entities;

namespace PrjCinema.MVC.Models
{
    public class EnderecoModelView
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres")]
        public string Rua { get; set; }
        [Required]
        [MaxLength(150, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres")]
        public string Bairro { get; set; }
        [Required]
        [MaxLength(150, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres")]
        public string Cidade { get; set; }
        public Uf Uf { get; set; }
        [Required]
        [DisplayName("Número")]
        [MaxLength(7, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(1, ErrorMessage = "Mínimo de {0} caracteres")]
        public int Numero { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(8, ErrorMessage = "Mínimo de {0} caracteres")]
        public string Cep { get; set; }
    }
}