using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Domain.Entities.Permissoes
{
    public class Operacao :  ITEntity
    {
        public int Id { get; set; }
        public bool Removido { get; set; }
        public string NomeOperacao { get; set; }

        public object Clone()
        {
            throw new System.NotImplementedException();
        }
    }
}