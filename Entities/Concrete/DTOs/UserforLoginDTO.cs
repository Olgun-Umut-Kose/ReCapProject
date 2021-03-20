using Core.Entities;

namespace Entities.Concrete.DTOs
{
    public class UserforLoginDTO : IDto
    {
        public string Email { get; set; }
        public string Pass { get; set; }
    }
}