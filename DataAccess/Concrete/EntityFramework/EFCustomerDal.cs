using System;
using System.Linq;
using System.Runtime.InteropServices;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.EntityFrameworkCore.Internal;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCustomerDal : EFEntityRepoBase<Customer, ReCapContext>, ICustomerDal
    {
        public bool CheckRentalsForCustomers(Customer customer)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Rentals.Any(r =>
                    r.CustomerId == customer.Id && r.ReturnDate == null);
            }
        }
    }
}