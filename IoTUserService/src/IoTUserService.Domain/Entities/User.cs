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
        public ICollection<Role>? Roles { get; set; }
    }
}
