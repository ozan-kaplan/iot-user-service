using IoTUserService.Domain.Repositories;
using MediatR;

namespace IoTUserService.Application.Features.UserCQ.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var device = await _unitOfWork.Users.GetByIdAsync(request.Id);
            if (device == null || device.IsDeleted)
                return false;

            device.UpdatedAt = DateTime.Now;
            device.IsDeleted = true;

            _unitOfWork.Users.Update(device);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
