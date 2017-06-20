using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PrjCinema.Data.Context;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity:class
    {
        protected ProjectContext context = new ProjectContext();
        public void Add(TEntity obj)
        {
            context.Set<TEntity>().Add(obj);
            context.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            context.Set<TEntity>().Remove(obj);
            context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
