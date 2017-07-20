using System;
using System.Collections.Generic;
using PrjCinema.Domain.Entities.Permissoes;
using PrjCinema.Domain.Interfaces.Repository;
using PrjCinema.Domain.Interfaces.Service;

namespace PrjCinema.Service.Service
{
    public class GrupoAcessoService : IGrupoAcessoService
    {
        private readonly IGrupoAcessoRepository _grupoAcessoRepository;
        public GrupoAcessoService(IGrupoAcessoRepository grupoAcessoRepository)
        {
            _grupoAcessoRepository = grupoAcessoRepository;
        }

        public void Add(GrupoAcesso obj)
        {
            _grupoAcessoRepository.Add(obj);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ICollection<GrupoAcesso> GetAll()
        {
            return _grupoAcessoRepository.GetAll();
        }

        public GrupoAcesso GetById(int id)
        {
            return _grupoAcessoRepository.GetById(id);
        }

        public void Remove(GrupoAcesso obj)
        {
            throw new NotImplementedException();
        }

        public void Update(GrupoAcesso obj)
        {
            _grupoAcessoRepository.Update(obj);
        }

        public void Desativar(GrupoAcesso obj)
        {
            obj.Removido = true;
            _grupoAcessoRepository.Update(obj);
        }

        public void Ativar(GrupoAcesso obj)
        {
            obj.Removido = false;
            _grupoAcessoRepository.Update(obj);
        }
    }
}