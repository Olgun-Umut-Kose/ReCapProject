using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal : InMemoryDalBaseRepo<Brand>
    {
        
        public override void Update(Brand entity)
        {
            Brand UpdateBrand = Get(e => entity.Id == e.Id);
            UpdateBrand.BrandName = entity.BrandName;
            
        }
    }
}
