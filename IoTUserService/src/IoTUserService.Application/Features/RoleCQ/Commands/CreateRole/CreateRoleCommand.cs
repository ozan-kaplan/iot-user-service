using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTUserService.Application.Features.RoleCQ.Commands.CreateRole
{
    public class CreateRoleCommand : IRequest<Guid>
    {
        public Guid CustomerId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
