using Core.Entities;

namespace Entities.Concrete.DTOs
{
    public class UserforRegisterDTO : IDto
    {
        public string Email { get; set; }
        public string Pass { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}