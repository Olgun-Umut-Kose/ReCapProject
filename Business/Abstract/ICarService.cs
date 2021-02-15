using Entities.Concrete;
using System.Collections.Generic;
using Core.Utilities.Results.Abstract;
using Entities.Concrete.DTOs;

namespace Business.Abstract
{
    public interface ICarService : IEntityService<Car>
    {
        IDataResult<List<CarDTO>> GetCarDetails();
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
    }
}
