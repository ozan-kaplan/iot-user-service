using IoTUserService.Domain.Repositories;
using MediatR;

namespace IoTUserService.Application.Features.UserCQ.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserCommandHandler(IUnitOfWork  unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var device = await _unitOfWork.Users.GetByIdAsync(request.Id);
            if (device == null)
                return false;

            device.UpdatedAt = DateTime.Now;
            device.Email = request.Email;
            device.FirstName = request.FirstName;
            device.LastName = request.LastName;
            device.GSMNumber = request.GSMNumber;

            _unitOfWork.Users.Update(device);
            
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
