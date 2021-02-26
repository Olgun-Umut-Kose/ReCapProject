using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Entities.Concrete.DTOs;
using Business.Constants;


namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _dal;

        public CarManager(ICarDal dal)
        {
            _dal = dal;
        }

        public IDataResult<Car> GetById(int id)
        {
            try
            {
                return new SuccessDataResult<Car>(Messages.Success, _dal.Get(c => c.Id.Equals(id)));
            }
            catch (Exception e)
            {
                return new ErrorDataResult<Car>(Messages.Error + e.Message, null);
            }
        }

        public IResult AddOrEdit(Car entity)
        {

            if (entity.Description.Length < 2)
            {
                return new ErrorResult(Messages.DescriptionError);
            }
            else if(entity.DailyPrice < 0)
            {
                return new ErrorResult(Messages.DailyPriceError);
            }
            else
            {
                try
                {
                    if (entity.Id == 0)
                    {
                        _dal.Add(entity);
                        return new SuccessResult(Messages.Added);
                    }
                    else
                    {
                        _dal.Update(entity);
                        return new SuccessResult(Messages.Updated);
                    }
                }
                catch (Exception e)
                {
                    return new ErrorResult(Messages.Error + e.Message);
                }
                
            }
            
        }

        public IResult Delete(Car entity)
        {
            try
            {
                bool result = _dal.CheckRentalsForCars(entity);
                if (!result)
                {
                    _dal.Delete(entity);
                    return new SuccessResult(Messages.Deleted);
                }

                return new ErrorResult(Messages.CarError);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.Error + e.Message);
            }
        }

        public IDataResult<List<Car>> GetAll(Func<Car,bool> filter = null)
        {
            try
            {
                return new SuccessDataResult<List<Car>>(Messages.Success, _dal.GetAll(filter));
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<Car>>(Messages.Error + e.Message, null);
            }
        }

        public IDataResult<Car> Get(Func<Car,bool> filter)
        {
            try
            {
                return new SuccessDataResult<Car>(Messages.Success, _dal.Get(filter));
            }
            catch (Exception e)
            {
                return new ErrorDataResult<Car>(Messages.Error + e.Message, null);
            }
        }

        public IDataResult<List<CarDTO>> GetCarDetails()
        {
            try
            {
                return new SuccessDataResult<List<CarDTO>>(Messages.Success, _dal.GetCarDetails());
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<CarDTO>>(Messages.Error + e.Message, null);
            }
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
