using System;
using System.Collections.Generic;
using PrjCinema.Domain.Entities;
using PrjCinema.Domain.Interfaces.Repository;
using PrjCinema.Domain.Interfaces.Service;

namespace PrjCinema.Service.Service
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public void Add(Endereco obj)
        {
            _enderecoRepository.Add(obj);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ICollection<Endereco> GetAll()
        {
            return _enderecoRepository.GetAll();
        }

        public Endereco GetById(int id)
        {
            return _enderecoRepository.GetById(id);
        }

        public void Remove(Endereco obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Endereco obj)
        {
            _enderecoRepository.Update(obj);
        }
    }
}
