using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.InMemory;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : InMemoryBaseRepo<Car>, ICarDal
    {
        public override void Update(Car entity)
        {
            Car updateCar = Get(e => e.Id == entity.Id);
            updateCar.BrandId = entity.BrandId;
            updateCar.ColorId = entity.ColorId;
            updateCar.DailyPrice = entity.DailyPrice;
            updateCar.Description = entity.Description;
            updateCar.ModelYear = entity.ModelYear;
            throw new NotImplementedException();
        }


        public List<CarDTO> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public CarDTO GetCarDetail(Func<CarDTO, bool> filter = null)
        {
            throw new NotImplementedException();
        }

        public bool CheckRentalsForCars(Car entity)
        {
            throw new NotImplementedException();
        }

        public List<CarDTO> GetCarDetails(Func<CarDTO, bool> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
