using System;
using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFRentalDal : EFEntityRepoBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDTO> GetRentalDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from r in context.Rentals
                    join c in context.Customers on r.CustomerId equals c.Id
                    join u in context.Users on c.UserId equals u.Id
                    join car in context.Cars on r.CarId equals car.Id
                    join b in context.Brands on car.BrandId equals b.Id
                    select new RentalDTO
                    {
                        BrandName = b.BrandName,
                        Id = r.Id,
                        CustomerName = u.FirstName + " " + u.LastName,
                        RentDate = r.RentDate,
                        ReturnDate = r.ReturnDate,
                    };
                return result.ToList();

            }
        }
    }
}