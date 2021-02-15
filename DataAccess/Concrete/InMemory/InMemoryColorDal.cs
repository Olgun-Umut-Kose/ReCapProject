using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.InMemory;
using DataAccess.Abstract;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : InMemoryBaseRepo<Color>,IColorDal
    {
        public InMemoryColorDal() : base()
        {
           
        }
        public override bool Update(Color entity)
        {
            return true;
        }
    }
}
