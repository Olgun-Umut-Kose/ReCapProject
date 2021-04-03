using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete.DTOs
{
    public class CarDTO : IDto
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public string ColorHexCode { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
