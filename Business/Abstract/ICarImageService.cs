using System;
using System.Collections.Generic;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult AddOrEdit(IFormFile file, CarImage entity, string type);
        IDataResult<List<string>> GetImagesByCarId(int carId);
        
        IDataResult<List<CarImage>> GetAll(Func<CarImage,bool> filter = null);
        IDataResult<CarImage> Get(Func<CarImage,bool> filter);
        IDataResult<CarImage> GetById(int id);
        
        IResult Delete(CarImage entity);
    }
}