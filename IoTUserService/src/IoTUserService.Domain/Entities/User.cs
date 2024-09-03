using IoTUserService.Shared.Enums;

namespace IoTUserService.Domain.Entities
{
    public class User : Entity
    {
        public Guid CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? GSMNumber { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public UserStatus Status { get; set; }  
        public UserAuthority Authority { get; set; }
        public ICollection<Role>? Roles { get; set; }
    }

    public enum UserAuthority
    {
        SystemAdmin,
        CustomerAdmin,
        CustomerUser
    }

    public enum UserStatus
    {
        Active,
        Inactive
    }
}
