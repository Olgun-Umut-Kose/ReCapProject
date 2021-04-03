using System;
using System.Collections.Generic;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult AddOrEdit(Rental entity);
        
        IDataResult<List<Rental>> GetAll(Func<Rental,bool> filter = null);
        IDataResult<Rental> Get(Func<Rental,bool> filter);
        IDataResult<Rental> GetById(int id);
        
        IResult Delete(Rental entity);
        IDataResult<List<RentalDTO>> GetRentalDetails();
    }
}