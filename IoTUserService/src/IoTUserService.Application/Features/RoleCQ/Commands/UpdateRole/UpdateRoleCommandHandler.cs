using IoTUserService.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTUserService.Application.Features.RoleCQ.Commands.UpdateRole
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateRoleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Roles.GetByIdAsync(request.Id);

            if (entity == null)
                throw new Exception("Role not found!");

            entity.UpdatedAt = DateTime.Now;
            entity.Name = request.Name;
            entity.Description = request.Description;

            _unitOfWork.Roles.Update(entity);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
