using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTUserService.Application.Features.RoleCQ.Commands.UpdateRole
{
    public class UpdateRoleCommand: IRequest<bool>
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; } 
    }
}
