using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Utilities.Results.Abstract;

namespace Core.DataAccess
{
    public interface IEntityRepo<T> where T: class, IEntity, new()
    {
        IDataResult<List<T>> GetAll(Func<T,bool> filter = null);
        IDataResult<T> Get(Func<T, bool> filter);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);

    }
}
