using IoTUserService.Domain.Entities;
using IoTUserService.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTUserService.Application.Features.RoleCQ.Commands.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateRoleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = new Role
            {
                CustomerId = request.CustomerId,
                Name = request.Name,
                Description = request.Description,
                CreatedAt  = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            await _unitOfWork.Roles.AddAsync(role);
            await _unitOfWork.SaveChangesAsync();

            return role.Id;
        }
    }
}
