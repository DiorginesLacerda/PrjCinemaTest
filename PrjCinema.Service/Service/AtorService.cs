using System;
using System.Collections.Generic;
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

        public bool IsAtorExiste(Ator representaAtor)
        {
            if (_atorRepository.GetAll().Any(u => u.Nome == representaAtor.Nome && u.DataNascimento == representaAtor.DataNascimento && u.Nacionalidade == representaAtor.Nacionalidade))
                return true;

            return false;
        }

        public void AddAtor(Ator representaAtor)
        {
            if (IsAtorExiste(representaAtor))
            {
                throw new Exception("O Ator" + representaAtor.Nome +" já esta cadastrado, por favor tente cadastrar outro Autor! Obrigado.");
            }

            _atorRepository.Add(representaAtor);
        }

        
    }
}
