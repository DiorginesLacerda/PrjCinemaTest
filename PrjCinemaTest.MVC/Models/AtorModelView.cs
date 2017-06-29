using System;
using System.ComponentModel.DataAnnotations;
using PrjCinema.Domain.Entities.SerieFilme;

namespace PrjCinema.MVC.Models
{
    public class AtorModelView
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Por favor insira um Nome.")]
        public string Nome { get; set; }
        public Nacionalidade Nacionalidade { get; set; }
        [Required(ErrorMessage = "É necessario inserir uma data de nascimento para o Ator. Utilize o Padrão dd/mm/aaaa.")]
        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy 00:00:00}")]
        //Este abaixo insere o datepicker, verificar depois pq que nao funciona !
        //[DataType(DataType.Date, ErrorMessage = "Data em formato inválido. Utilize o Padrão dd/mm/aaaa.")]
        public DateTime DataNascimento { get; set; }
    }
}