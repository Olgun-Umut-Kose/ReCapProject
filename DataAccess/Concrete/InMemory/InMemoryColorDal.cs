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
            _entities.Add(new Color
            {
                Id = 1,
                ColorName = "Siyah",
                HexCode = "#000000"
            });
            _entities.Add(new Color
            {
                Id = 2,
                ColorName = "Beyaz",
                HexCode = "#FFFFFF"
            });
            _entities.Add(new Color
            {
                Id = 3,
                ColorName = "Kırmızı",
                HexCode = "#FF0000"
            });
        }
        public override void Update(Color entity)
        {
            
        }
    }
}
