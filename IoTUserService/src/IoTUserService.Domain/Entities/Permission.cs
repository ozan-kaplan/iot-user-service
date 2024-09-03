using IoTUserService.Shared.Enums;

namespace IoTUserService.Domain.Entities
{
    public class Permission : Entity
    {
        public PermissionResource Resource { get; set; }
        public PermissionOperation Operation { get; set; } 

    }
}
