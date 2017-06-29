
namespace PrjCinema.MVC.Models
{
    public class AtuaFilmeModelView
    {
        public int Id { get; set; }
        public int FilmeId { get; set; }
        public virtual FilmeModelView Filme { get; set; }
        public int AtorId { get; set; }
        public virtual AtorModelView Ator { get; set; }
    }
}