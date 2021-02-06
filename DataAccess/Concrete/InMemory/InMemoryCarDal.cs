using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : InMemoryDalBaseRepo<Car>
    {
        public override void Update(Car entity)
        {
            Car UpdateCar = Get(e => e.Id == entity.Id);
            UpdateCar.BrandId = entity.BrandId;
            UpdateCar.ColorId = entity.ColorId;
            UpdateCar.DailyPrice = entity.DailyPrice;
            UpdateCar.Description = entity.Description;
            UpdateCar.ModelYear = entity.ModelYear;
            
        }
    }
}
