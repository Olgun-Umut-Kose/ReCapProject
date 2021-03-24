using System;
using System.Collections.Generic;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandService 
    {
        IResult AddOrEdit(Brand entity);
        
        IDataResult<List<Brand>> GetAll(Func<Brand,bool> filter = null);
        IDataResult<Brand> Get(Func<Brand,bool> filter);
        IDataResult<Brand> GetById(int id);
        
        IResult Delete(Brand entity);
    }
}