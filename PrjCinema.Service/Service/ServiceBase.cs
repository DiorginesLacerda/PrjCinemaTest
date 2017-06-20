using System;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Service.Service
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity:class
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;
        public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public void Add(TEntity obj)
        {
            _repositoryBase.Add(obj);
        }

        public TEntity GetById(int id)
        {
            return _repositoryBase.GetById(id);
        }

        public System.Collections.Generic.IEnumerable<TEntity> GetAll()
        {
            return _repositoryBase.GetAll();
        }

        public void Update(TEntity obj)
        {
            _repositoryBase.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _repositoryBase.Remove(obj);
        }

        public void Dispose()
        {
            _repositoryBase.Dispose();
        }
    }
}
