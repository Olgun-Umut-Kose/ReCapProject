using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using Business.Constants;
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

        public IDataResult<Color> GetById(int id)
        {

            return new SuccessDataResult<Color>(Messages.Success, _dal.Get(c => c.Id.Equals(id)));

        }

        public IResult AddOrEdit(Color entity)
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

        public IResult Delete(Color entity)
        {

            _dal.Delete(entity);
            return new SuccessResult(Messages.Deleted);

        }

        public IDataResult<List<Color>> GetAll(Func<Color, bool> filter = null)
        {
            return new SuccessDataResult<List<Color>>(Messages.Success, _dal.GetAll(filter));

        }

        public IDataResult<Color> Get(Func<Color, bool> filter)
        {

            return new SuccessDataResult<Color>(Messages.Success, _dal.Get(filter));

        }


    }

}
