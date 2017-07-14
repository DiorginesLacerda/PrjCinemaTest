using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PrjCinema.Domain.Entities.SerieFilme;

namespace PrjCinema.MVC.Models
{
    public class FilmeModelView
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Por favor insira um Titulo para o Filme.")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Por favor insira uma Descrição para o Filme.")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public Nacionalidade Nacionalidade { get; set; }
        [Required(ErrorMessage = "Por favor insira qual o tempo duração do Filme.")]
        [Display(Name = "Tempo de Duração")]
        public string Duracao { get; set; }
        [Required(ErrorMessage = "É necessário inserir uma data de lançamento para o Filme. Utilize o Padrão dd/mm/aaaa.")]
        [Display(Name = "Data de Lançamento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Lancamento { get; set; }
        public Categoria Categoria { get; set; }
        public virtual ICollection<Ator> FilmeAtores { get; set; }
        
    }
}