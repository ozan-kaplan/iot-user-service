using IoTUserService.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTUserService.Application.Features.RoleCQ.Commands.DeleteRole
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteRoleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {

            var entity = await _unitOfWork.Roles.GetByIdAsync(request.Id);

            if (entity == null)
                throw new Exception("Role not found!");

            entity.UpdatedAt = DateTime.Now;
            entity.IsDeleted = true;

            _unitOfWork.Roles.Update(entity);
            await _unitOfWork.SaveChangesAsync();

            return true;

        }
    }
}
