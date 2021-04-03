﻿using Entities.Concrete;
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
                        ModelYear = c.ModelYear.Year
                    };
                return filter == null
                    ? CarList.ToList()
                    : CarList.Where(filter).ToList();
            }
        }

        public bool CheckRentalsForCars(Car entity)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return (context.Rentals.Any(r =>
                    r.CarId == entity.Id && r.ReturnDate == null));
            }
        }
    }
}