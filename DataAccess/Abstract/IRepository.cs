using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;



namespace DataAccess.Abstract
{
    public interface IRepository<T> where T: class, IEntity, new()
    {
        List<T> GetAll(Func<T, bool> filter = null);
        T Get(Func<T,bool> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
