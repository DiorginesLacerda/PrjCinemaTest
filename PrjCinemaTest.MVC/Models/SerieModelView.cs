

using System;

using System.ComponentModel.DataAnnotations;

using PrjCinema.Domain.Entities.SerieFilme;

namespace PrjCinema.MVC.Models
{
    public class SerieModelView
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Por favor insira um Titulo para o Filme.")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Por favor insira uma Descrição para o Filme.")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public Nacionalidade Nacionalidade { get; set; }
        [Required]
        [Display(Name = "Quantidade de episódios")]
        public int QntEpisodio { get; set; }
        [Required(ErrorMessage = "É necessário inserir uma data de lançamento para o Filme. Utilize o Padrão dd/mm/aaaa.")]
        [Display(Name = "Data de Lançamento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        //[DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime Lancamento { get; set; }
        public Categoria Categoria { get; set; }
        
    }
}