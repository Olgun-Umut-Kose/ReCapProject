using System;
using System.Collections.Generic;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColorService 
    {
        IResult AddOrEdit(Color entity);
        
        IDataResult<List<Color>> GetAll(Func<Color,bool> filter = null);
        IDataResult<Color> Get(Func<Color,bool> filter);
        IDataResult<Color> GetById(int id);
        
        IResult Delete(Color entity);
    }
}