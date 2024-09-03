using IoTUserService.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTUserService.Application.Features.RoleCQ.Commands.AssignPermission
{
    public class AssignPermissionsToRoleCommand: IRequest<bool>
    {
        public required Guid RoleId { get; set; }
        public required List<PermissionDto> Permissions { get; set; }

        public AssignPermissionsToRoleCommand(Guid roleId, List<PermissionDto> permissions)
        {
            RoleId = roleId;
            Permissions = permissions;
        }
    }
}
