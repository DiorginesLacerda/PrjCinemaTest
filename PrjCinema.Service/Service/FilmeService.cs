using System;
using System.Collections.Generic;
using System.Linq;
using PrjCinema.Domain.Entities.SerieFilme;
using PrjCinema.Domain.Interfaces.Repository;
using PrjCinema.Domain.Interfaces.Service;

namespace PrjCinema.Service.Service
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeService(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;

        }

        public void Add(Filme obj)
        {
            if (IsFilmeExiste(obj))
            {
                throw new Exception("O Filme " + obj.Titulo + " já esta cadastrado, por favor tente cadastrar outro Filme! Obrigado.");
            }

            _filmeRepository.Add(obj);
        }

        public IEnumerable<Filme> BuscaFilmesPorAtor(int id)
        {
            return BuscaFilmesPorAtor(id);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ICollection<Filme> GetAll()
        {
            return _filmeRepository.GetAll();
        }

        public Filme GetById(int id)
        {
            return _filmeRepository.GetById(id);
        }

        public void Remove(Filme obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Filme obj)
        {
            if (IsFilmeExiste(obj))
            {
                _filmeRepository.Update(obj);
            }
            else
            {
                throw new Exception("Erro ao tentar editar o filme, por favor cheque novamente os dados inseridos.");
            }
        }

        public bool IsFilmeExiste(Filme representaFilme)
        {
            if (_filmeRepository.GetAll().Any(u => u.Id == representaFilme.Id))
                return true;

            return false;
        }

        //public void AddFilme(Filme representaFilme)
        //{
        //    if (IsFilmeExiste(representaFilme))
        //    {
        //        throw new Exception("O Filme " + representaFilme.Titulo + " já esta cadastrado, por favor tente cadastrar outro Filme! Obrigado.");
        //    }

        //    _filmeRepository.Add(representaFilme);
        //}

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

        //public void EditaFilme(Filme representaFilme)
        //{
        //    if (IsFilmeExiste(representaFilme))
        //    {
        //        _filmeRepository.Update(representaFilme);
        //    }
        //    else
        //    {
        //        throw new Exception("Erro ao tentar editar o filme, por favor cheque novamente os dados inseridos.");
        //    }
        //}

        //public IEnumerable<Filme> BuscaFilmesPorAtor(int id)
        //{
        //    return _filmeRepository.BuscaFilmesPorAtor(id);
        //}

        public void Desativar(Filme obj)
        {
            obj.Removido = true;
            _filmeRepository.Update(obj);
        }

        public void Ativar(Filme obj)
        {
            obj.Removido = false;
            _filmeRepository.Update(obj);
        }

    }
}
