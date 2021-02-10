using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;

namespace Core.DataAccess.InMemory
{
    public abstract class InMemoryBaseRepo<T> : IEntityRepo<T> where T : class, IEntity,new()
    {
        
        int id;
        protected List<T> _entities;

        protected InMemoryBaseRepo()
        {
            _entities = new List<T>();
            id = 1;
        }


        public List<T> GetAll(Func<T, bool> filter = null)
        {
            return filter == null ? _entities : _entities.Where(filter).ToList();
        }

        public T Get(Func<T, bool> filter)
        {
            return _entities.SingleOrDefault(filter);
        }

        public void Add(T entity)
        {
            entity.Id = id;
            _entities.Add(entity);
            id++;
        }

        public abstract void Update(T entity);
        

        public void Delete(T entity)
        {
            T deleteEntity = Get(e => e.Id == entity.Id);
            _entities.Remove(deleteEntity);
        }

    }
}