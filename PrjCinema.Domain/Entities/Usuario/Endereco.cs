
namespace PrjCinema.Domain.Entities
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public Uf Uf { get; set; }
        public int Numero { get; set; }
        public string Cep { get; set; }
    }
}
