using IoTUserService.Application.Models;
using IoTUserService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTUserService.Application.Features.PermissionCQ.Queries.GetPermissionsByUserId
{
    public class GetPermissionsByUserIdQuery: IRequest<List<PermissionDto>>
    {
        public Guid UserId { get; set; }

        public GetPermissionsByUserIdQuery(Guid userId)
        {
            UserId = userId;
        }   
    }
}
