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
        public bool CheckCustomersForUsers(User entity)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Customers.Any(c =>
                    c.UserId == entity.Id && (context.Rentals.Any(r => r.CustomerId == c.Id && r.ReturnDate == null)));
            }
        }
    }
}