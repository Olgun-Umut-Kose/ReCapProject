using System;
using System.Linq;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFUserDal : EFEntityRepoBase<User, ReCapContext>, IUserDal
    {
        public IDataResult<bool?> CheckCustomersForUsers(User entity)
        {
            try
            {
                using (ReCapContext context = new ReCapContext())
                {

                    return new SuccessDataResult<bool?>(context.Customers.Any(c => c.UserId == entity.Id && (context.Rentals.Any(r => r.CustomerId == c.Id && r.ReturnDate == null))));
                    
                }
                
            }
            catch (Exception)
            {
                
                return new ErrorDataResult<bool?>(null);
            }
        }
    }
}