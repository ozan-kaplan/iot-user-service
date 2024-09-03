using MediatR;

namespace IoTUserService.Application.Features.UserCQ.Commands.CreateUser
{

    public class CreateUserCommand : IRequest<Guid>
    {
        public Guid CustomerId { get; set; }
        public required string Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? GSMNumber { get; set; }
        public required string Password { get; set; }
    }
}
