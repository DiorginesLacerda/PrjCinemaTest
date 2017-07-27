using System;
using System.Collections.Generic;
using System.Linq;
using PrjCinema.Domain.Entities.Permissoes;
using PrjCinema.Domain.Interfaces.Repository;
using PrjCinema.Domain.Interfaces.Service;

namespace PrjCinema.Service.Service
{
    public class PermissaoService : IPermissaoService
    {
        private readonly IPermissaoRepository _permissaoRepository;
        private readonly GrupoAcessoService _grupoAcessoService;

        public PermissaoService(IPermissaoRepository permissaoRepository, GrupoAcessoService grupoAcessoService)
        {
            _grupoAcessoService = grupoAcessoService;
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

        //public ICollection<Permissao> GetPermissoesDoGrupo(int id)
        //{
        //    var permGrupoId = new List<int>();
        //    var permissoes = new List<Permissao>();
        //    foreach (var pG in _grupoAcessoService.GetById(id).Permissoes.OrderBy(x => x.Id))
        //    {
        //        permGrupoId.Add(pG.Id);
        //    }
        //    foreach (var ids in permGrupoId)
        //    {
        //        permissoes.Add(_permissaoRepository.GetById(ids));
        //    }
        //    return permissoes;
        //}

        public ICollection<Permissao> GetPermissoesFaltantesNoGrupo(int id)
        {
            var permGrupoId = new List<int>();
            var permissoes = new List<Permissao>();
            bool ok = false;
            int whatever = 0;

            foreach (var pG in _grupoAcessoService.GetById(id).Permissoes.OrderBy(x => x.Id))
            {
                permGrupoId.Add(pG.Id);
            }
            foreach (var p in _permissaoRepository.GetAll().OrderBy(x => x.Id))
            {
                permGrupoId.Add(p.Id);
            }
            permGrupoId.Sort();
            for (int i = 0; i < permGrupoId.Count; whatever++)
            {
                if (permGrupoId.Count > i + 1)
                {
                    if (permGrupoId[i] == permGrupoId[i + 1])
                    {
                        permGrupoId.Remove(permGrupoId[i]);
                        ok = true;
                    }
                    else if (permGrupoId[i] != permGrupoId[i + 1])
                    {
                        ok = false;
                    }

                    if (ok)
                    {
                        permGrupoId.Remove(permGrupoId[i]);
                        continue;
                    }
                    i++;
                }
                else
                {
                  break;  
                }
             }
            foreach (var ids in permGrupoId)
            {
                permissoes.Add(_permissaoRepository.GetById(ids));
            }
            return permissoes;
        }
    }
}
