using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Brand : IEntity
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        

    }
}
