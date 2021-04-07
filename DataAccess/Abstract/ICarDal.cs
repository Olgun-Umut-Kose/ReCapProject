using System;
using System.Collections.Generic;
using Core.DataAccess;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepo<Car>
    {
        List<CarDTO> GetCarDetails(Func<CarDTO,bool> filter = null);
        CarDTO GetCarDetail(Func<CarDTO,bool> filter = null);
        bool CheckRentalsForCars(Car entity);
    }
}