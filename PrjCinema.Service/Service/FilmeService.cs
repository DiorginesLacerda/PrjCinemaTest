using System;
using System.Linq;
using PrjCinema.Domain.Entities.SerieFilme;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Service.Service
{
    public class FilmeService: ServiceBase<Filme>, IFilmeService
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeService(IFilmeRepository filmeRepository)
            :base(filmeRepository)
        {
            _filmeRepository = filmeRepository;

        }

        public bool IsAtorExiste(Filme representaFilme)
        {
            if (_filmeRepository.GetAll().Any(u => u.Titulo == representaFilme.Titulo && u.Lancamento == representaFilme.Lancamento && u.Nacionalidade == representaFilme.Nacionalidade))
                return true;

            return false;
        }

        public void AddFilme(Filme representaFilme)
        {
            if (IsAtorExiste(representaFilme))
            {
                throw new Exception("O Filme " + representaFilme.Titulo + " já esta cadastrado, por favor tente cadastrar outro Filme! Obrigado.");
            }

            _filmeRepository.Add(representaFilme);
        }
    }
}
