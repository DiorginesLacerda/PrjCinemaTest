using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PrjCinema.Data.Context;
using PrjCinema.Data.Repositories.ContextFactory;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity>
      where TEntity : class, ITEntity
    {

        internal ProjectContext _context;
        internal DbSet<TEntity> dbSet;
        
        public RepositoryBase(IContextFactory _contextFactory)
        {
            _context = _contextFactory.GetContext();
            dbSet = _context.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            dbSet.Add(obj);
            _context.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return dbSet.Find(id);
        }

        public ICollection<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public void Update(TEntity obj)
        {   
            var old = dbSet.Where(x => x.Id == obj.Id).Single();
            _context.Entry(old).CurrentValues.SetValues(obj);
            _context.Entry(old).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            Update(obj);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
