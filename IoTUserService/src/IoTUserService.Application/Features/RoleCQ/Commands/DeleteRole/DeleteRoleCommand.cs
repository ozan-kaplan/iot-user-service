using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTUserService.Application.Features.RoleCQ.Commands.DeleteRole
{
    public class DeleteRoleCommand: IRequest<bool>
    {
        public DeleteRoleCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
