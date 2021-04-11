using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Business.BusinessAspects.AutoFac;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Entities.Concrete.DTOs;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.AutoFac;
using Core.Aspect.AutoFac.Caching;
using Core.Utilities.Filter;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Core.Utilities.Business;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _dal;
        IBrandService _brandService;

        public CarManager(ICarDal dal, IBrandService brandService)
        {
            _dal = dal;
            _brandService = brandService;
        }

        [CacheAspect()]
        public IDataResult<Car> GetById(int id)
        {

            return new SuccessDataResult<Car>(Messages.Success, _dal.Get(c => c.Id.Equals(id)));

        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult AddOrEdit(Car entity)
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

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car entity)
        {

            IResult result = BusinessRules.Run(CheckRentalsForCars(entity.Id));
            if (result != null)
            {
                _dal.Delete(entity);
                return new SuccessResult(Messages.Deleted);
            }

            return new ErrorResult(Messages.CarError);

        }

        [CacheAspect()]
        public IDataResult<List<Car>> GetAll(Func<Car, bool> filter = null)
        {
            return new SuccessDataResult<List<Car>>(Messages.Success, _dal.GetAll(filter));

        }

        public IDataResult<Car> Get(Func<Car, bool> filter)
        {

            return new SuccessDataResult<Car>(Messages.Success, _dal.Get(filter));

        }

        public IDataResult<List<CarDTO>> GetCarDetails(Func<CarDTO, bool> filter = null)
        {

            return new SuccessDataResult<List<CarDTO>>(Messages.Success, _dal.GetCarDetails(filter));

        }

        public IDataResult<CarDTO> GetCarDetailById(int id)
        {
            return GetCarDetail(c => c.Id == id);
        }

        public IDataResult<CarDTO> GetCarDetail(Func<CarDTO, bool> filter)
        {
            return new SuccessDataResult<CarDTO>(Messages.Success, _dal.GetCarDetail(filter));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return GetAll(c => c.BrandId == id);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return GetAll(c => c.ColorId == id);
        }

        public IDataResult<List<CarDTO>> GetCarDetailsFilter(CarDetailFilterDto filterDto)
        {

            foreach (PropertyInfo property in filterDto.GetType().GetProperties())
            {
                if ((int)property.GetValue(filterDto) == 0)
                {
                    property.SetValue(filterDto, null);
                }
            }


            Func<CarDTO, bool> filter = FilterHelper.DynamicFilter<CarDTO, CarDetailFilterDto>(filterDto);
            return GetCarDetails(filter);

        }

        private IResult CheckRentalsForCars(int carId)
        {
            if (_dal.CheckRentalsForCars(carId))
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
    }
}