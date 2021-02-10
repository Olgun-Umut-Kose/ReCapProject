using System.Collections.Generic;
using Core.DataAccess;
using Entities.Concrete;
using Entities.Concrete.DTOs;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepo<Car>
    {
        List<CarDTO> GetCarDetails();
    }
}