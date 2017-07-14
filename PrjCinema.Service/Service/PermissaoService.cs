using System;
using System.Collections.Generic;
using PrjCinema.Domain.Entities.Permissoes;
using PrjCinema.Domain.Interfaces.Repository;
using PrjCinema.Domain.Interfaces.Service;

namespace PrjCinema.Service.Service
{
    public class PermissaoService: IPermissaoService
    {
        private readonly IPermissaoRepository _permissaoRepository;

        public PermissaoService(IPermissaoRepository permissaoRepository)
        {
            _permissaoRepository = permissaoRepository;
        }

        public void Add(Permissao obj)
        {
            Add(obj);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ICollection<Permissao> GetAll()
        {
            return _permissaoRepository.GetAll();
        }

        public Permissao GetById(int id)
        {
            return _permissaoRepository.GetById(id);
        }

        public void Remove(Permissao obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Permissao obj)
        {
            Update(obj);
        }
    }
}
