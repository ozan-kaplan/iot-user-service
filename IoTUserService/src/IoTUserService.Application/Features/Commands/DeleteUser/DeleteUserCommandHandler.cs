using IoTUserService.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTUserService.Application.Features.Commands.DeleteUser
{  
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var device = await _userRepository.GetByIdAsync(request.Id);
            if (device == null || device.IsDeleted)
                return false;

            device.UpdatedAt = DateTime.Now;
            device.IsDeleted = true;

            await _userRepository.UpdateAsync(device);

            return true;
        }
    }
}
