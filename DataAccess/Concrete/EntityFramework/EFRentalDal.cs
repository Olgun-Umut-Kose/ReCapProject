using System;
using System.Linq;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFRentalDal : EFEntityRepoBase<Rental,ReCapContext>, IRentalDal
    {
        public IDataResult<bool?> Any( Func<Rental, bool> filter)
        {
            try
            {
                using (ReCapContext context = new ReCapContext())
                {
                    return new SuccessDataResult<bool?>(context.Rentals.Any(filter));
                }
            }
            catch (Exception)
            {
                return new ErrorDataResult<bool?>(null);
            }
        }
    }
}