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
            return _dal.GetAll(filter);
        }

        public IDataResult<Customer> Get(Func<Customer, bool> filter)
        {
            return _dal.Get(filter);
        }

        public IResult AddOrEdit(Customer entity)
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

        public IResult Delete(Customer entity)
        {
            bool? result = _dal.CheckRentalsForCustomers(entity).Data;
            if (result != null && (bool) !result)
            {
                return new Result(_dal.Delete(entity));
                    
            }

            return new ErrorResult(Messages.CustomerorUserDeleteError);
        }
    }
}