namespace IoTUserService.Domain.Entities
{
    public class Permission : Entity
    {
        public PermissionScope Scope { get; set; }
        public PermissionType Type { get; set; }
        public string? Description { get; set; }
    }

    public enum PermissionType
    {
        Read,
        Write,
        Delete
    }

    public enum PermissionScope
    {
        User,
        Device,
        DeviceType,
        DeviceGroup,
        UserGroup
    }
}
