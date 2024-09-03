using IoTUserService.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTUserService.Application.Features.RoleCQ.Queries.GetRoleById
{
    public class GetRoleByIdQuery: IRequest<RoleDto>
    {
        public Guid Id { get; set; }

        public GetRoleByIdQuery(Guid id)
        {
            Id = id;
        }

    }
}
