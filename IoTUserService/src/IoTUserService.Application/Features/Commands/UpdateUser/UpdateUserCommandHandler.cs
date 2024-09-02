using IoTUserService.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTUserService.Application.Features.Commands.UpdateUser
{ 
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository  userRepository)
        {
            _userRepository =  userRepository;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var device = await _userRepository.GetByIdAsync(request.Id);
            if (device == null)
                return false;

            device.Email = request.Email;
            device.FirstName = request.FirstName;
            device.LastName = request.LastName;
            device.GSMNumber = request.GSMNumber;

            await _userRepository.UpdateAsync(device);

            return true;
        }
    }
}
