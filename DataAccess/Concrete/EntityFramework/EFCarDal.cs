using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarDal : EFEntityRepoBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDTO> GetCarDetails(Func<CarDTO,bool> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var CarList = from c in context.Cars
                    join b in context.Brands on c.BrandId equals b.Id
                    join clr in context.Colors on c.ColorId equals clr.Id
                    select new CarDTO
                    {
                        Id = c.Id,
                        BrandId = c.BrandId,
                        BrandName = b.BrandName,
                        ColorId = c.ColorId,
                        ColorName = clr.ColorName,
                        ColorHexCode = clr.HEXCode,
                        DailyPrice = c.DailyPrice,
                        Description = c.Description,
                        ModelYear = c.ModelYear
                    };
                return filter == null
                    ? CarList.ToList()
                    : CarList.Where(filter).ToList();
            }
        }

        public CarDTO GetCarDetail(Func<CarDTO, bool> filter)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var Car = from c in context.Cars
                    join b in context.Brands on c.BrandId equals b.Id
                    join clr in context.Colors on c.ColorId equals clr.Id
                    select new CarDTO
                    {
                        Id = c.Id,
                        BrandId = c.BrandId,
                        BrandName = b.BrandName,
                        ColorId = c.ColorId,
                        ColorName = clr.ColorName,
                        ColorHexCode = clr.HEXCode,
                        DailyPrice = c.DailyPrice,
                        Description = c.Description,
                        ModelName = c.ModelName,
                        ModelYear = c.ModelYear
                    };
                return Car.FirstOrDefault(filter);
            } 
        }

        public bool CheckRentalsForCars(int carId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Rentals.Any(r =>
                    r.CarId == carId && (r.ReturnDate == null || r.ReturnDate > DateTime.UtcNow));
            }
        }
    }
}