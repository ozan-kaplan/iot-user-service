namespace IoTUserService.Domain.Entities
{
    public class Role : Entity
    {
        public Guid CustomerId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Permission> Permissions { get; set; } = new List<Permission>();

    }
}
