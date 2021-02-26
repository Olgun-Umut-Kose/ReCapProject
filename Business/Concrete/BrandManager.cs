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
            try
            {
                return new SuccessDataResult<Brand>(Messages.Success, _dal.Get(b => b.Id.Equals(id)));
            }
            catch (Exception e)
            {
                return new ErrorDataResult<Brand>(Messages.Error + e.Message, null);
            }
        }

        public IResult AddOrEdit(Brand entity)
        {
            try
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
            catch (Exception e)
            {
                return new ErrorResult(Messages.Error + e.Message);
            }
        }

        public IResult Delete(Brand entity)
        {
            try
            {
                _dal.Delete(entity);
                return new SuccessResult(Messages.Deleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.Error + e.Message);
            }
        }

        public IDataResult<List<Brand>> GetAll(Func<Brand,bool> filter = null)
        {
            try
            {
                return new SuccessDataResult<List<Brand>>(Messages.Success, _dal.GetAll(filter));
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<Brand>>(Messages.Error + e.Message, null);
            }
        }

        public IDataResult<Brand> Get(Func<Brand,bool> filter)
        {
            try
            {
                return new SuccessDataResult<Brand>(Messages.Success, _dal.Get(filter));
            }
            catch (Exception e)
            {
                return new ErrorDataResult<Brand>(Messages.Error + e.Message, null);
            }
        }


    }


}
