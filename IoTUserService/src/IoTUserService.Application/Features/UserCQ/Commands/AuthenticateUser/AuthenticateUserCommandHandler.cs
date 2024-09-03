using IoTUserService.Application.Interfaces.Security;
using IoTUserService.Application.Models;
using IoTUserService.Domain.Repositories;
using MediatR;

namespace IoTUserService.Application.Features.UserCQ.Commands.AuthenticateUser
{
    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, AuthenticateResponseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticateUserCommandHandler(IUnitOfWork  unitOfWork, IPasswordHasher passwordHasher, IJwtTokenGenerator jwtTokenGenerator)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<AuthenticateResponseDto> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(request.Email);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid credentials.");
            }

            var passwordMatches = _passwordHasher.VerifyPassword(user.PasswordHash, request.Password);
            if (!passwordMatches)
            {
                throw new UnauthorizedAccessException("Invalid credentials.");
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticateResponseDto(token);
        }
    }
}
