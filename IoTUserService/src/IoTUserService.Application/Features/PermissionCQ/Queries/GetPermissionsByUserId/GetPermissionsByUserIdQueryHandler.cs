using IoTUserService.Application.Models;
using IoTUserService.Domain.Entities;
using IoTUserService.Domain.Repositories;
using IoTUserService.Shared.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTUserService.Application.Features.PermissionCQ.Queries.GetPermissionsByUserId
{
    public class GetPermissionsByUserIdQueryHandler : IRequestHandler<GetPermissionsByUserIdQuery, List<PermissionDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPermissionsByUserIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PermissionDto>> Handle(GetPermissionsByUserIdQuery request, CancellationToken cancellationToken)
        {

            var user = await _unitOfWork.Users.GetByIdAsync(request.UserId);
            if (user == null) 
                throw new Exception("User not found!");

            List<PermissionDto> result = new List<PermissionDto>();

            switch (user.Authority)
            {
                case UserAuthority.SystemAdmin:
                    // System Admin has all permissions
                    result = Enum.GetValues(typeof(PermissionResource))
                        .Cast<PermissionResource>()
                        .SelectMany(resource => Enum.GetValues(typeof(PermissionOperation))
                            .Cast<PermissionOperation>()
                            .Select(operation => new PermissionDto
                            {
                                Resource = resource,
                                Operation = operation
                            }))
                        .ToList();
                    break;
                case UserAuthority.CustomerAdmin:
                    // Customer Admin has all permissions except Customer
                    result = Enum.GetValues(typeof(PermissionResource))
                        .Cast<PermissionResource>()
                        .Where(resource => resource != PermissionResource.Customer)
                        .SelectMany(resource => Enum.GetValues(typeof(PermissionOperation))
                            .Cast<PermissionOperation>()
                            .Select(operation => new PermissionDto
                            {
                                Resource = resource,
                                Operation = operation
                            }))
                        .ToList();
                    break;
                case UserAuthority.CustomerUser:
                    // Customer Admin has all permissions except Customer and only read permission for resources
                    result = Enum.GetValues(typeof(PermissionResource))
                        .Cast<PermissionResource>()
                        .Where(resource => resource != PermissionResource.Customer)
                        .SelectMany(resource => Enum.GetValues(typeof(PermissionOperation))
                            .Cast<PermissionOperation>()
                            .Where(operation => operation == PermissionOperation.Read)
                            .Select(operation => new PermissionDto
                            {
                                Resource = resource,
                                Operation = operation
                            }))
                        .ToList();
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
