using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjCinema.MVC.Models
{
    public class AtuaSerieModelView
    {
        public int Id { get; set; }
        public int SerieId { get; set; }
        public virtual SerieModelView Serie { get; set; }
        public int AtorId { get; set; }
        public virtual AtorModelView Ator { get; set; }
    }
}