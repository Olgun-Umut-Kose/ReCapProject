using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarDal : EFEntityRepoBase<Car,ReCapContext>,ICarDal
    {
        public List<CarDTO> GetCarDetails()
        {
            var CarList = from c in GetAll()
                join b in new  EFBrandDal().GetAll() on c.BrandId equals b.Id
                join clr in new EFColorDal().GetAll() on c.ColorId equals clr.Id
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
