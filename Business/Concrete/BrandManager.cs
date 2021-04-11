using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using Business.Constants;
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

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(Messages.Success, _dal.Get(b => b.Id.Equals(id)));
        }

        public IResult AddOrEdit(Brand entity)
        {
            if (entity.Id == 0)
            {
                _dal.Add(entity);
                return new SuccessResult(Messages.Added);
            }
            else
            {
                _dal.Update(entity);
                return new SuccessResult(Messages.Updated);
            }

        }

        public IResult Delete(Brand entity)
        {

            _dal.Delete(entity);
            return new SuccessResult(Messages.Deleted);

        }

        public IDataResult<List<Brand>> GetAll(Func<Brand, bool> filter = null)
        {

            return new SuccessDataResult<List<Brand>>(Messages.Success, _dal.GetAll(filter));

        }

        public IDataResult<Brand> Get(Func<Brand, bool> filter)
        {

            return new SuccessDataResult<Brand>(Messages.Success, _dal.Get(filter));

        }


    }


}
