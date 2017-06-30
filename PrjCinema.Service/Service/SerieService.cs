using System;
using System.Linq;
using PrjCinema.Domain.Entities.SerieFilme;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Service.Service
{
    public class SerieService: ServiceBase<Serie>, ISerieService
    {
        private readonly ISerieRepository _serieRepository;

        public SerieService(ISerieRepository serieRepository)
            :base(serieRepository)
        {
            _serieRepository = serieRepository;
        }

        public bool IsFilmeExiste(Serie representaSerie)
        {
            if (_serieRepository.GetAll().Any(u => u.Titulo == representaSerie.Titulo && u.Lancamento == representaSerie.Lancamento && u.Nacionalidade == representaSerie.Nacionalidade))
                return true;

            return false;
        }

        public void AddFilme(Serie representaSerie)
        {
            if (IsFilmeExiste(representaSerie))
            {
                throw new Exception("A Serie " + representaSerie.Titulo + " já esta cadastrada, por favor tente cadastrar outro Serie! Obrigado.");
            }

            _serieRepository.Add(representaSerie);
        }

        public bool IsTituloIgualAOutroFilme(Serie representaSerie)
        {
            foreach (var serieList in _serieRepository.GetAll())
            {
                if (representaSerie.Id != serieList.Id && representaSerie.Titulo == serieList.Titulo)
                {
                    return true;
                }
            }
            return false;
        }

        public void EditaFilme(Serie representaSerie)
        {
            if (IsFilmeExiste(representaSerie) && !IsTituloIgualAOutroFilme(representaSerie))
            {
                _serieRepository.Update(representaSerie);
            }
            else
            {
                throw new Exception("Erro ao tentar editar a serie, por favor cheque novamente os dados inseridos.");
            }
        }
    }
}
