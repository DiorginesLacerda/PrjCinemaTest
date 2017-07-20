using System;
using System.Collections.Generic;
using System.Linq;
using PrjCinema.Domain.Entities.SerieFilme;
using PrjCinema.Domain.Interfaces.Repository;
using PrjCinema.Domain.Interfaces.Service;

namespace PrjCinema.Service.Service
{
    public class SerieService : ISerieService
    {
        private readonly ISerieRepository _serieRepository;

        public SerieService(ISerieRepository serieRepository)
            {
            _serieRepository = serieRepository;
        }

        public bool IsFilmeExiste(Serie representaSerie)
        {
            if (_serieRepository.GetAll().Any(u => u.Titulo == representaSerie.Titulo &&
                                                   u.Lancamento == representaSerie.Lancamento &&
                                                   u.Nacionalidade == representaSerie.Nacionalidade))
                return true;

            return false;
        }

        public void AddFilme(Serie representaSerie)
        {
            if (IsFilmeExiste(representaSerie))
            {
                throw new Exception("A Serie " + representaSerie.Titulo +
                                    " já esta cadastrada, por favor tente cadastrar outro Serie! Obrigado.");
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

        
        public IEnumerable<Serie> BuscaSeriesPorAtor(int id)
        {
            return _serieRepository.BuscaSeriesPorAtor(id);
        }

        public void Add(Serie obj)
        {
            _serieRepository.Add(obj);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ICollection<Serie> GetAll()
        {
            return _serieRepository.GetAll();
        }

        public Serie GetById(int id)
        {
            return _serieRepository.GetById(id);
        }

        public void Remove(Serie obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Serie obj)
        {
            _serieRepository.Update(obj);
        }

        public void Desativar(Serie obj)
        {
            obj.Removido = true;
            _serieRepository.Update(obj);
        }

        public void Ativar(Serie obj)
        {
            obj.Removido = false;
            _serieRepository.Update(obj);
        }
    }
}
