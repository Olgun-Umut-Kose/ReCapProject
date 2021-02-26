using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _dal;

        public UserManager(IUserDal dal)
        {
            _dal = dal;
        }


        public IDataResult<List<User>> GetAll(Func<User, bool> filter = null)
        {
            try
            {
                return new SuccessDataResult<List<User>>(Messages.Success, _dal.GetAll(filter));
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<User>>(Messages.Error + e.Message, null);
            }
        }

        public IDataResult<User> Get(Func<User, bool> filter)
        {
            try
            {
                return new SuccessDataResult<User>(Messages.Success, _dal.Get(filter));
            }
            catch (Exception e)
            {
                return new ErrorDataResult<User>(Messages.Error + e.Message, null);
            }
        }

        public IDataResult<User> GetById(int id)
        {
            try
            {
                return new SuccessDataResult<User>(Messages.Success, _dal.Get(u => u.Id.Equals(id)));
            }
            catch (Exception e)
            {
                return new ErrorDataResult<User>(Messages.Error + e.Message, null);
            }
        }

        public IResult AddOrEdit(User entity)
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

        public IResult Delete(User entity)
        {
            try
            {
                bool result = _dal.CheckCustomersForUsers(entity);
                if (!result)
                {
                    _dal.Delete(entity);
                    return new SuccessResult(Messages.Deleted);
                }

                return new ErrorResult(Messages.CustomerorUserDeleteError);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.Error + e.Message);
            }
        }
    }
}