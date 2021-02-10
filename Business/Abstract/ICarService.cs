using Entities.Concrete;
using System.Collections.Generic;
using Entities.Concrete.DTOs;

namespace Business.Abstract
{
    public interface ICarService : IService<Car>
    {
        List<CarDTO> GetCarDetails();
        List<Car> GetCarsByBrandId(int id);
        List<Car> GetCarsByColorId(int id);
    }
}
