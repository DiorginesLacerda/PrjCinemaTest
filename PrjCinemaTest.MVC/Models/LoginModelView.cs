using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace PrjCinema.MVC.Models
{
    public class LoginModelView
    {
        [Required, EmailAddress(ErrorMessage = "É necessário um email válido.")]
        [MaxLength(150, ErrorMessage = "Máximo de {0} caracteres")]
        [DisplayName("E-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Por favor insira a sua Senha.", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}