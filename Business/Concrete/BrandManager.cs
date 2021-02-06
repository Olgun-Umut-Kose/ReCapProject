using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class BrandManager : IService<Brand>
    {
        IRepository<Brand> _dal;

        public BrandManager(IRepository<Brand> dal)
        {
            _dal = dal;
        }

        public void AddOrEdit(Brand entity)
        {
            if (entity.Id == 0)
            {
                _dal.Add(entity);
            }
            else
            {
                _dal.Update(entity);
            }
        }

        public void Delete(Brand entity)
        {
            _dal.Delete(entity);
        }

        public List<Brand> GetAll(Func<Brand,bool> filter = null)
        {
            return _dal.GetAll(filter);
        }

        public Brand Get(Func<Brand,bool> filter)
        {
            return _dal.Get(filter);
        }


    }


}
