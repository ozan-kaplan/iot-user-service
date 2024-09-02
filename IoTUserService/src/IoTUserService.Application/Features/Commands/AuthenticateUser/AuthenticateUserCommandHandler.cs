using IoTUserService.Application.Interfaces.Repositories;
using IoTUserService.Application.Interfaces.Security;
using IoTUserService.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTUserService.Application.Features.Commands.AuthenticateUser
{
    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, AuthenticateResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticateUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<AuthenticateResponseDto> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
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
