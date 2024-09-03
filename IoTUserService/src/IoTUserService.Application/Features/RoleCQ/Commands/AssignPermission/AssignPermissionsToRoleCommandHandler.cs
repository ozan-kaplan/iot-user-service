using IoTUserService.Domain.Entities;
using IoTUserService.Domain.Repositories;
using MediatR;

namespace IoTUserService.Application.Features.RoleCQ.Commands.AssignPermission
{
    public class AssignPermissionsToRoleCommandHandler : IRequestHandler<AssignPermissionsToRoleCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssignPermissionsToRoleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AssignPermissionsToRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var existingPermissions = await _unitOfWork.Permissions.GetPermissionsByRoleIdAsync(request.RoleId);
                if (existingPermissions != null)
                    await _unitOfWork.Permissions.BulkDeleteAsync(existingPermissions);


                var newRolePermissions = request.Permissions.Select(p => new Permission()
                {
                    Id = Guid.NewGuid(),
                    RoleId = request.RoleId,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Resource = p.Resource,
                    Operation = p.Operation
                }).ToList();

                await _unitOfWork.Permissions.BulkInsertAsync(newRolePermissions);

                await _unitOfWork.SaveChangesAsync();

                await _unitOfWork.CommitTransactionAsync();
            }
            catch
            {
                throw new Exception("An error occurred while assigning permissions to role.");
            }

            return true;

        }
    }
}
