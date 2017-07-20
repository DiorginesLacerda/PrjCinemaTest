using System;
using System.Collections.Generic;
using System.Linq;
using PrjCinema.Domain.Entities.SerieFilme;
using PrjCinema.Domain.Interfaces.Repository;
using PrjCinema.Domain.Interfaces.Service;

namespace PrjCinema.Service.Service
{
    public class AtorService : IAtorService
    {
        private readonly IAtorRepository _atorRepository;

        public AtorService(IAtorRepository atorRepository)
        {
            _atorRepository = atorRepository;
        }

        public void Add(Ator obj)
        {
            _atorRepository.Add(obj);
        }

        public IEnumerable<Ator> BuscaAtoresPorFilme(int id)
        {
            return _atorRepository.BuscaAtoresPorFilme(id);
        }

        public IEnumerable<Ator> BuscaAtoresPorSerie(int id)
        {
            return _atorRepository.BuscaAtoresPorSerie(id);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ICollection<Ator> GetAll()
        {
            return _atorRepository.GetAll();
        }

        public Ator GetById(int id)
        {
            return _atorRepository.GetById(id);
        }

        public void Remove(Ator obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Ator obj)
        {
            _atorRepository.Update(obj);
        }

        public bool IsAtorExiste(Ator representaAtor)
        {
            if (_atorRepository.GetAll().Any(u => u.Nome == representaAtor.Nome && u.DataNascimento == representaAtor.DataNascimento && u.Nacionalidade == representaAtor.Nacionalidade))
                return true;

            return false;
        }

        //public void AddAtor(Ator representaAtor)
        //{
        //    if (IsAtorExiste(representaAtor))
        //    {
        //        throw new Exception("O Ator " + representaAtor.Nome + " já esta cadastrado, por favor tente cadastrar outro Ator! Obrigado.");
        //    }

        //    _atorRepository.Add(representaAtor);
        //}

        //public void EditarAtor(Ator representaAtor)
        //{
        //    if (IsAtorExiste(representaAtor))
        //    {
        //        throw new Exception("Os dados que você tentou alterar do Ator são iguais ao de um outro Ator, por favor certifique-se dos dados inseridos.");
        //    }
        //    _atorRepository.Update(representaAtor);
        //}

        //public IEnumerable<Ator> BuscaAtoresPorFilme(int id)
        //{
        //    return _atorRepository.BuscaAtoresPorFilme(id);
        //}

        //public IEnumerable<Ator> BuscaAtoresPorSerie(int id)
        //{
        //    return _atorRepository.BuscaAtoresPorSerie(id);
        //}

        public void Desativar(Ator obj)
        {
            obj.Removido = true;
            _atorRepository.Update(obj);
        }

        public void Ativar(Ator obj)
        {
            obj.Removido = false;
            _atorRepository.Update(obj);
        }
    }
}
