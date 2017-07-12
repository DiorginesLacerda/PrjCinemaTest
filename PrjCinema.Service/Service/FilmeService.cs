using System;
using System.Collections.Generic;
using System.Linq;
using PrjCinema.Domain.Entities.SerieFilme;
using PrjCinema.Domain.Interfaces.Repository;
using PrjCinema.Domain.Interfaces.Service;

namespace PrjCinema.Service.Service
{
    public class FilmeService : ServiceBase<Filme>, IFilmeService
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeService(IFilmeRepository filmeRepository)
            : base(filmeRepository)
        {
            _filmeRepository = filmeRepository;

        }

        public bool IsFilmeExiste(Filme representaFilme)
        {
            if (_filmeRepository.GetAll().Any(u=> u.Id == representaFilme.Id))
                return true;

            return false;
        }

        public void AddFilme(Filme representaFilme)
        {
            if (IsFilmeExiste(representaFilme))
            {
                throw new Exception("O Filme " + representaFilme.Titulo + " já esta cadastrado, por favor tente cadastrar outro Filme! Obrigado.");
            }

            _filmeRepository.Add(representaFilme);
        }

        public bool IsTituloIgualAOutroFilme(Filme representaFilme)
        {
            foreach (var filmesList in _filmeRepository.GetAll())
            {
                if (representaFilme.Id != filmesList.Id && representaFilme.Titulo == filmesList.Titulo)
                {
                    return true;
                }
            }
            return false;
        }

        public void EditaFilme(Filme representaFilme)
        {
            if (IsFilmeExiste(representaFilme))
            {
                _filmeRepository.Update(representaFilme);
            }
            else
            {
                throw new Exception("Erro ao tentar editar o filme, por favor cheque novamente os dados inseridos.");
            }
        }

        public IEnumerable<Filme> BuscaFilmesPorAtor(int id)
        {
            return _filmeRepository.BuscaFilmesPorAtor(id);
        }

       
    }
}
