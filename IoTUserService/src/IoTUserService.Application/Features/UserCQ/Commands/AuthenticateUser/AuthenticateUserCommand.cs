using IoTUserService.Application.Models;
using MediatR;

namespace IoTUserService.Application.Features.UserCQ.Commands.AuthenticateUser
{
    public class AuthenticateUserCommand : IRequest<AuthenticateResponseDto>
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
