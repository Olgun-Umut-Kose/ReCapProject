using System;
using Entities.Concrete;
using System.Collections.Generic;
using Core.Utilities.Results.Abstract;
using Entities.Concrete.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<CarDTO>> GetCarDetails(Func<CarDTO,bool> filter = null);
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        
        IResult AddOrEdit(Car entity);
        
        IDataResult<List<Car>> GetAll(Func<Car,bool> filter = null);
        IDataResult<Car> Get(Func<Car,bool> filter);
        IDataResult<Car> GetById(int id);
        
        IResult Delete(Car entity);
        IDataResult<List<CarDTO>> GetCarDetailsFilter(CarDetailFilterDto filterDto);
    }
}
