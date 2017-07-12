using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PrjCinema.Data.Context;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity>
      where TEntity : class, ITEntity
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

        public ICollection<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            var dbset = context.Set<TEntity>();
            var old = dbset.Where(x => x.Id == obj.Id).Single();
            context.Entry(old).CurrentValues.SetValues(obj);
            context.Entry(old).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            Update(obj);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
