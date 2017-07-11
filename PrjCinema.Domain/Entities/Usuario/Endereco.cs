
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Domain.Entities
{
    public class Endereco : ITEntity
    {
        public int Id { get; set; }
        public bool Removido { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public Uf Uf { get; set; }
        public int Numero { get; set; }
        public string Cep { get; set; }
        //public int UsuarioId { get; set; }
        //public Usuario Usuario { get; set; }
        public object Clone()
        {
            throw new System.NotImplementedException();
        }
    }
}
