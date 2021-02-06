using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public abstract class InMemoryDalBaseRepo<T> : IRepository<T> where T : class, IEntity, new()
    {
        int id;
        protected List<T> _entities;
        protected InMemoryDalBaseRepo()
        {
            _entities = new List<T>();
            id = 1;
        }
        public virtual void Add(T entity)
        {
            entity.Id = id;
            _entities.Add(entity);
            id++;
        }

        public virtual void Delete(T entity)
        {
            T DeleteEntity = Get(e => e.Id == entity.Id);
            _entities.Remove(DeleteEntity);
        }

        public virtual List<T> GetAll(Func<T, bool> filter = null)
        {

            return filter == null ? _entities : _entities.Where(filter).ToList(); 
        }

        

        public abstract void Update(T entity);

        public T Get(Func<T, bool> filter)
        {
            return _entities.FirstOrDefault(filter);
        }
    }
}
