using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.InMemory;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : InMemoryBaseRepo<Color>,IColorDal
    {
        public InMemoryColorDal() : base()
        {
           
        }
        public override void Update(Color entity)
        {
            throw new NotImplementedException();
        }
    }
}
