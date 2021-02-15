using System.Collections.Generic;
using Core.DataAccess;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepo<Car>
    {
        IDataResult<List<CarDTO>> GetCarDetails();
    }
}