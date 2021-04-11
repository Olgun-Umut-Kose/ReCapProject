using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _dal;

        public CustomerManager(ICustomerDal dal)
        {
            _dal = dal;
        }


        public IDataResult<List<Customer>> GetAll(Func<Customer, bool> filter = null)
        {

            return new SuccessDataResult<List<Customer>>(Messages.Success, _dal.GetAll(filter));

        }

        public IDataResult<Customer> Get(Func<Customer, bool> filter)
        {

            return new SuccessDataResult<Customer>(Messages.Success, _dal.Get(filter));

        }

        public IDataResult<Customer> GetById(int id)
        {

            return new SuccessDataResult<Customer>(Messages.Success, _dal.Get(c => c.Id.Equals(id)));

        }

        public IResult AddOrEdit(Customer entity)
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

        public IResult Delete(Customer entity)
        {

            IResult result = BusinessRules.Run(CheckRentalsForCustomers(entity.Id));
            if (result != null)
            {
                _dal.Delete(entity);
                return new SuccessResult(Messages.Deleted);
            }

            return new ErrorResult(Messages.CustomerorUserDeleteError);

        }

        private IResult CheckRentalsForCustomers(int customerId)
        {
            if (_dal.CheckRentalsForCustomers(customerId))
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
    }
}