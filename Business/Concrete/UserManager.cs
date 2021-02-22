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
            return _dal.GetAll(filter);
        }

        public IDataResult<User> Get(Func<User, bool> filter)
        {
            return _dal.Get(filter);
        }

        public IResult AddOrEdit(User entity)
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

        public IResult Delete(User entity)
        {
            bool? result = _dal.CheckCustomersForUsers(entity).Data;
            if (result != null && (bool) !result)
            {
                
                return new Result(_dal.Delete(entity));
            }

            return new ErrorResult(Messages.CustomerorUserDeleteError);
        }
    }
}