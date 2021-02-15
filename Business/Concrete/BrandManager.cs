using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _dal;

        public BrandManager(IBrandDal dal)
        {
            _dal = dal;
        }

        public IResult AddOrEdit(Brand entity)
        {
            if (entity.Id == 0)
            {
                return new Result(_dal.Add(entity));
            }
            else
            {
                return new Result(_dal.Update(entity));
            }
        }

        public IResult Delete(Brand entity)
        {
            return new Result(_dal.Delete(entity));
        }

        public IDataResult<List<Brand>> GetAll(Func<Brand,bool> filter = null)
        {
            return _dal.GetAll(filter);
        }

        public IDataResult<Brand> Get(Func<Brand,bool> filter)
        {
            return _dal.Get(filter);
        }


    }


}
