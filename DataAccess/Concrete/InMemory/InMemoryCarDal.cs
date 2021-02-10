using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.InMemory;
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
            
        }

        public List<CarDTO> GetCarDetails()
        {
            var CarList = from c in GetAll()
                join b in new InMemoryBrandDal().GetAll() on c.BrandId equals b.Id
                join clr in new InMemoryColorDal().GetAll() on c.ColorId equals clr.Id
                select new CarDTO
                {
                    Id = c.Id,
                    BrandName = b.BrandName,
                    ColorName = clr.ColorName,
                    ColorsHexCode = clr.HexCode,
                    DailyPrice = c.DailyPrice,
                    Description = c.Description,
                    ModelYear = c.ModelYear.Year
                };
            return CarList.ToList();
        }
    }
}
