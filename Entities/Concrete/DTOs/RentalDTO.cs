using System;
using Core.Entities;

namespace Entities.Concrete.DTOs
{
    public class RentalDTO : IDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string CustomerName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}