using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.InMemory;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal : InMemoryBaseRepo<Brand>, IBrandDal
    {
        
        public override void Update(Brand entity)
        {
            Brand updateBrand = Get(e => entity.Id == e.Id);
            updateBrand.BrandName = entity.BrandName;
            throw new NotImplementedException();
        }
        
    }
}
