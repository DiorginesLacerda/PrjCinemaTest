using System.Linq;
using PrjCinema.Domain.Entities.SerieFilme;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Service.Service
{
    public class AtorService : ServiceBase<Ator>, IAtorService
    {
        private readonly IAtorRepository _atorRepository;

        public AtorService(IAtorRepository atorRepository)
            :base (atorRepository)
        {
            _atorRepository = atorRepository;
        }

        public bool AtorExiste(Ator representaAtor)
        {
            if (_atorRepository.GetAll().Any(u => u.Nome == representaAtor.Nome && u.DataNascimento == representaAtor.DataNascimento && u.Nacionalidade == representaAtor.Nacionalidade))
                return true;

            return false;
        }
    }
}
