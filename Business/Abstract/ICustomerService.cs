using System;
using System.Collections.Generic;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult AddOrEdit(Customer entity);
        
        IDataResult<List<Customer>> GetAll(Func<Customer,bool> filter = null);
        IDataResult<Customer> Get(Func<Customer,bool> filter);
        IDataResult<Customer> GetById(int id);
        
        IResult Delete(Customer entity);
    }
}