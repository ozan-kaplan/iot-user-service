using IoTUserService.Shared.Enums;

namespace IoTUserService.Domain.Entities
{
    public class Permission : Entity
    {
        public Guid RoleId { get; set; }
        public PermissionResource Resource { get; set; }
        public PermissionOperation Operation { get; set; } 

    }
}
