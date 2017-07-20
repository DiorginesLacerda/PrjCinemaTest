using System;
using System.Collections.Generic;
using System.Linq;
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
            _permissaoRepository.Add(obj);
        }

        public IEnumerable<Permissao> BuscaPermissoesPorGrupoAcesso(int id)
        {

            return _permissaoRepository.GetAll().Where(u => u.GrupoAcesso.Any(x => x.Id == id));
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
            _permissaoRepository.Update(obj);
        }

        public void Desativar(Permissao obj)
        {
            obj.Removido = true;
            _permissaoRepository.Update(obj);
        }

        public void Ativar(Permissao obj)
        {
            obj.Removido = false;
            _permissaoRepository.Update(obj);
        }
    }
}
