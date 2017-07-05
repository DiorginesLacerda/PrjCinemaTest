using System;
using System.Collections.Generic;
using System.Linq;
using PrjCinema.Domain.Entities.Relacoes;
using PrjCinema.Domain.Interfaces.Repository;
using PrjCinema.Domain.Interfaces.Service;

namespace PrjCinema.Service.Service
{
    public class AtuaFilmeService : ServiceBase<AtuaFilme>, IAtuaFilmeService
    {
        private readonly IAtuaFilmeRepository _atuaFilmeRepository;

        public AtuaFilmeService(IAtuaFilmeRepository atuaFilmeRepository)
            :base(atuaFilmeRepository)
        {
            _atuaFilmeRepository = atuaFilmeRepository;
        }

        public IEnumerable<AtuaFilme> BuscaFilmePorAtor(int id)
        {
            return _atuaFilmeRepository.BuscaFilmePorAtor(id);
        }

        public IEnumerable<AtuaFilme> BuscaAtorPorFilme(int id)
        {
            return _atuaFilmeRepository.BuscaAtorPorFilme(id);
        }

        public bool IsAtuacaoExiste(AtuaFilme atuaFilme)
        {

            if (_atuaFilmeRepository.GetAll().Any(u => u.FilmeId == atuaFilme.FilmeId && u.AtorId == atuaFilme.AtorId))
            {
                return true;
            }
            return false;
        }

        public void AddAtuacaoFilme(AtuaFilme representaAtuacaoFilme)
        {
            if (IsAtuacaoExiste(representaAtuacaoFilme))
            {
                throw new Exception("O Ator " + representaAtuacaoFilme.Ator.Nome + " já esta cadastrado como ator neste filme, por favor tente cadastrar outro Ator caso necessário! Obrigado.");
            }

            _atuaFilmeRepository.Add(representaAtuacaoFilme);
        }
    }
}
