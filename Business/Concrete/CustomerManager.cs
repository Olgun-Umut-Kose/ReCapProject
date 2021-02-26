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
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _dal;

        public CustomerManager(ICustomerDal dal)
        {
            _dal = dal;
        }


        public IDataResult<List<Customer>> GetAll(Func<Customer, bool> filter = null)
        {
            try
            {
                return new SuccessDataResult<List<Customer>>(Messages.Success, _dal.GetAll(filter));
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<Customer>>(Messages.Error + e.Message, null);
            }
        }

        public IDataResult<Customer> Get(Func<Customer, bool> filter)
        {
            try
            {
                return new SuccessDataResult<Customer>(Messages.Success, _dal.Get(filter));
            }
            catch (Exception e)
            {
                return new ErrorDataResult<Customer>(Messages.Error + e.Message, null);
            }
        }

        public IDataResult<Customer> GetById(int id)
        {
            try
            {
                return new SuccessDataResult<Customer>(Messages.Success, _dal.Get(c => c.Id.Equals(id)));
            }
            catch (Exception e)
            {
                return new ErrorDataResult<Customer>(Messages.Error + e.Message, null);
            }
        }

        public IResult AddOrEdit(Customer entity)
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

        public IResult Delete(Customer entity)
        {
            try
            {
                bool result = _dal.CheckRentalsForCustomers(entity);
                if (!result)
                {
                    _dal.Delete(entity);
                    return new SuccessResult(Messages.Deleted);
                }

                return new ErrorResult(Messages.CustomerorUserDeleteError);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.Error + e.Message);
            }
        }
    }
}