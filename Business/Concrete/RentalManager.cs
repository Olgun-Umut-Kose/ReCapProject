using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
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

            return new SuccessDataResult<List<Rental>>(Messages.Success, _dal.GetAll(filter));

        }

        public IDataResult<Rental> Get(Func<Rental, bool> filter)
        {
            return new SuccessDataResult<Rental>(Messages.Success, _dal.Get(filter));

        }

        public IDataResult<Rental> GetById(int id)
        {

            return new SuccessDataResult<Rental>(Messages.Success, _dal.Get(r => r.Id.Equals(id)));

        }

        public IResult AddOrEdit(Rental entity)
        {

            if (entity.Id == 0)
            {
                IResult result = BusinessRules.Run(CheckRentals(entity));
                if (result != null)
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

        public IResult Delete(Rental entity)
        {

            IResult result = BusinessRules.Run(CheckRentals(entity));
            if (result != null)
            {
                _dal.Delete(entity);
                return new SuccessResult(Messages.Deleted);
            }

            return new ErrorResult(message: Messages.CarError);

        }

        public IDataResult<List<RentalDTO>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDTO>>(Messages.Success, _dal.GetRentalDetails());
        }

        private IResult CheckRentals(Rental rental)
        {
            if(!_dal.Any(r => r.CarId == rental.CarId && (r.ReturnDate == null || r.ReturnDate > DateTime.UtcNow)))
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}