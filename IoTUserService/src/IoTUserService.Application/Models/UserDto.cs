using IoTUserService.Domain.Entities;

namespace IoTUserService.Application.Models
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public UserAuthority Authority { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? GSMNumber { get; set; }
        public required string Email { get; set; }
    }
}
