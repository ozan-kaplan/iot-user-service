using MediatR;

namespace IoTUserService.Application.Features.UserCQ.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
