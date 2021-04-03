using System;
using System.Collections.Generic;
using Core.DataAccess;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepo<Rental>
    {
        List<RentalDTO> GetRentalDetails();
    }
}