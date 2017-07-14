using System.Collections.Generic;

namespace PrjCinema.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> 
        where TEntity: class 
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        ICollection<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}