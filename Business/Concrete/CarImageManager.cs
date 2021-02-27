using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _dal;

        public CarImageManager(ICarImageDal dal)
        {
            _dal = dal;
        }


        public IDataResult<List<CarImage>> GetAll(Func<CarImage, bool> filter = null)
        {
            try
            {
                return new SuccessDataResult<List<CarImage>>(Messages.Success, _dal.GetAll(filter));
                
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<CarImage>>(Messages.Error + e.Message, null);
            }
        }

        public IDataResult<CarImage> Get(Func<CarImage, bool> filter)
        {
            try
            {
                return new SuccessDataResult<CarImage>(Messages.Success, _dal.Get(filter));
                
            }
            catch (Exception e)
            {
                return new ErrorDataResult<CarImage>(Messages.Error + e.Message, null);
            }
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return Get(ci => ci.Id == id);
        }

        public IResult Delete(CarImage entity)
        {
            try
            {
                string path = Get(ci => ci.Id == entity.Id).Data.ImagePath;
                FileHelper.Delete(path);
                _dal.Delete(entity);
                return new SuccessResult(Messages.Deleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.Error + e.Message);
            }
        }

        public IResult AddOrEdit(IFormFile file, CarImage entity, string type)
        {
            try
            {
                IResult result = BusinessRules.Run(CheckCarImageLimit(entity));
                if (result != null) return result;

                if (entity.Id == 0)
                {
                    string path = FileHelper.Save(file, type).Data;

                    entity.ImagePath = path;
                    _dal.Add(entity);
                    return new SuccessResult(Messages.Added);

                }
                else
                {
                    string path = Get(ci => ci.Id == entity.Id).Data.ImagePath;
                    FileHelper.Delete(path);
                    string updatedPath = FileHelper.Save(file, type).Data;
                    entity.ImagePath = updatedPath;
                    _dal.Update(entity);
                    return new SuccessResult(Messages.Updated);
                }
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.Error + e.Message+"--"+ e.InnerException?.Message);
            }
        }

        private IResult CheckCarImageLimit(CarImage entity)
        {
            if (_dal.GetAll(ci => ci.CarId == entity.CarId).Count >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitError);
            }

            return new SuccessResult();
        }
    }
}