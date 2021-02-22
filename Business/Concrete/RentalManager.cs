using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

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
            return _dal.GetAll(filter);
        }

        public IDataResult<Rental> Get(Func<Rental, bool> filter)
        {
            return _dal.Get(filter);
        }

        public IResult AddOrEdit(Rental entity)
        {
            if (entity.Id == 0)
            {
                bool? result = _dal.Any(r => r.CarId == entity.CarId && r.ReturnDate == null).Data;
                if (result != null && (bool) !result)
                {
                    return new Result(_dal.Add(entity));
                    
                }
                return new ErrorResult(message: Messages.CarError);
            }
            else
            {
                return new Result(_dal.Update(entity));
            }
        }

        public IResult Delete(Rental entity)
        {
            bool? result = _dal.Any(r => r.CarId == entity.CarId && r.ReturnDate == null).Data;
            if (result != null && (bool) !result)
            {
                return new Result(_dal.Delete(entity));
                    
            }
            return new ErrorResult(message: Messages.CarError);
        }
    }
}