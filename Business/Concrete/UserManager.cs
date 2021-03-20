using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;


namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _dal;

        public UserManager(IUserDal dal)
        {
            _dal = dal;
        }


        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            try
            {
                List<OperationClaim> result = _dal.GetClaims(user);
                return new SuccessDataResult<List<OperationClaim>>(Messages.Success, result);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<OperationClaim>>(Messages.Error + e.Message, null);
                
            }
            
            
        }

        public IResult Add(User user)
        {
            try
            {
                _dal.Add(user);
                return new SuccessResult(Messages.Success);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.Error + e.Message);
            }
        }

        public IDataResult<User> GetByMail(string email)
        {
            try
            {
                User result = _dal.Get(u => u.Email == email);
                return new SuccessDataResult<User>(Messages.Success, result);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<User>(Messages.Error + e.Message, null);
            }
            
        }
    }
}