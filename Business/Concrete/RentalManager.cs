using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Storage;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _dal;

        public RentalManager(IRentalDal dal)
        {
            _dal = dal;
        }

        public IDataResult<List<Rental>> GetAll(Func<Rental, bool> filter = null)
        {
            try
            {
                return new SuccessDataResult<List<Rental>>(Messages.Success, _dal.GetAll(filter));
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<Rental>>(Messages.Error + e.Message, null);
            }
        }

        public IDataResult<Rental> Get(Func<Rental, bool> filter)
        {
            try
            {
                return new SuccessDataResult<Rental>(Messages.Success, _dal.Get(filter));
            }
            catch (Exception e)
            {
                return new ErrorDataResult<Rental>(Messages.Error + e.Message, null);
            }
        }

        public IDataResult<Rental> GetById(int id)
        {
            try
            {
                return new SuccessDataResult<Rental>(Messages.Success, _dal.Get(r => r.Id.Equals(id)));
            }
            catch (Exception e)
            {
                return new ErrorDataResult<Rental>(Messages.Error + e.Message, null);
            }
        }

        public IResult AddOrEdit(Rental entity)
        {
            try
            {
                if (entity.Id == 0)
                {
                    bool result = _dal.Any(r => r.CarId == entity.CarId && r.ReturnDate == null);
                    if (!result)
                    {
                        _dal.Add(entity);
                        return new SuccessResult(Messages.Added);
                    }

                    return new ErrorResult(Messages.CarError);
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

        public IResult Delete(Rental entity)
        {
            try
            {
                bool result = _dal.Any(r => r.CarId == entity.CarId && r.ReturnDate == null);
                if (!result)
                {
                    _dal.Delete(entity);
                    return new SuccessResult(Messages.Deleted);
                }

                return new ErrorResult(message: Messages.CarError);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.Error + e.Message);
            }
        }
    }
}