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
            try
            {
                return new SuccessDataResult<Color>(Messages.Success, _dal.Get(c => c.Id.Equals(id)));
            }
            catch (Exception e)
            {
                return new ErrorDataResult<Color>(Messages.Error + e.Message, null);
            }
        }

        public IResult AddOrEdit(Color entity)
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

        public IResult Delete(Color entity)
        {
            try
            {
                _dal.Delete(entity);
                return new SuccessResult(Messages.Deleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.Error + e.Message);
            }
        }

        public IDataResult<List<Color>> GetAll(Func<Color,bool> filter = null)
        {
            try
            {
                return new SuccessDataResult<List<Color>>(Messages.Success, _dal.GetAll(filter));
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<Color>>(Messages.Error + e.Message, null);
            }
        }

        public IDataResult<Color> Get(Func<Color,bool> filter)
        {
            try
            {
                return new SuccessDataResult<Color>(Messages.Success, _dal.Get(filter));
            }
            catch (Exception e)
            {
                return new ErrorDataResult<Color>(Messages.Error + e.Message, null);
            }
        }


    }

}
