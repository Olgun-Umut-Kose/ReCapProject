using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Entities.Concrete.DTOs;


namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _dal;

        public CarManager(ICarDal dal)
        {
            _dal = dal;
        }

        public IResult AddOrEdit(Car entity)
        {

            if (entity.Description.Length > 2 && entity.DailyPrice > 0)
            {
                if (entity.Id == 0)
                {
                    return new Result(_dal.Add(entity));
                }
                else
                {
                    return new Result(_dal.Update(entity));
                }
            }
            else
            {
                return new ErrorResult("değişiklik yapamazsın çünkü kurallara uymuyorsun");
            }
            
        }

        public IResult Delete(Car entity)
        {
            return new Result(_dal.Delete(entity));
        }

        public IDataResult<List<Car>> GetAll(Func<Car,bool> filter = null)
        {
            return _dal.GetAll(filter);
        }

        public IDataResult<Car> Get(Func<Car,bool> filter)
        {
            return _dal.Get(filter);
        }

        public IDataResult<List<CarDTO>> GetCarDetails()
        {
            return _dal.GetCarDetails();
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return GetAll(c => c.BrandId == id);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return GetAll(c => c.ColorId == id);
        }
    }
}
