using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IService<T> where T: IEntity
    {
        List<T> GetAll(Func<T,bool> filter = null);
        T Get(Func<T,bool> filter);
        void AddOrEdit(T entity);
        void Delete(T entity);
    }
}
