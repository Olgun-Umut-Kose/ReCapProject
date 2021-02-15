using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _dal;

        public ColorManager(IColorDal dal)
        {
            _dal = dal;
        }

        public IResult AddOrEdit(Color entity)
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

        public IResult Delete(Color entity)
        {
            return new Result(_dal.Delete(entity));
            
            
        }

        public IDataResult<List<Color>> GetAll(Func<Color,bool> filter = null)
        {
            return _dal.GetAll(filter);
        }

        public IDataResult<Color> Get(Func<Color,bool> filter)
        {
            return _dal.Get(filter);
        }


    }

}
