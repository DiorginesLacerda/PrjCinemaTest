using System;
using System.Collections.Generic;
using System.Linq;
using PrjCinema.Domain.Entities.Relacoes;
using PrjCinema.Domain.Interfaces.Repository;
using PrjCinema.Domain.Interfaces.Service;

namespace PrjCinema.Service.Service
{
    public class AtuaSerieService : ServiceBase<AtuaSerie>, IAtuaSerieService
    {
        private readonly IAtuaSerieRepository _atuaSerieRepository;

        public AtuaSerieService(IAtuaSerieRepository atuaSerieRepository)
            :base(atuaSerieRepository)
        {
            _atuaSerieRepository = atuaSerieRepository;
        }

        public IEnumerable<AtuaSerie> BuscaSeriePorAtor(int id)
        {
            return _atuaSerieRepository.BuscaSeriePorAtor(id);
        }

        public IEnumerable<AtuaSerie> BuscaAtorPorSerie(int id)
        {
            return _atuaSerieRepository.BuscaAtorPorSerie(id);
        }


        public bool IsAtuacaoExiste(AtuaSerie atuaSerie)
        {

            if (_atuaSerieRepository.GetAll().Any(u => u.SerieId == atuaSerie.SerieId && u.AtorId == atuaSerie.AtorId))
            {
                return true;
            }
            return false;
        }

        public void AddAtuacaoFilme(AtuaSerie representaAtuacaoFilme)
        {
            if (IsAtuacaoExiste(representaAtuacaoFilme))
            {
                throw new Exception("O Ator " + representaAtuacaoFilme.Ator.Nome + " já esta cadastrado como ator nesta serie, por favor tente cadastrar outro Ator caso necessário! Obrigado.");
            }

            _atuaSerieRepository.Add(representaAtuacaoFilme);
        }
    }
}
