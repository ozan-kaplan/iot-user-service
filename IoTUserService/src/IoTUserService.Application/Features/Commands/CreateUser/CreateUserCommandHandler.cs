using IoTUserService.Application.Interfaces.Repositories;
using IoTUserService.Application.Interfaces.Security;
using IoTUserService.Domain.Entities;
using MediatR;

namespace IoTUserService.Application.Features.Commands.CreateUser
{

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public CreateUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                GSMNumber = request.GSMNumber,
                Email = request.Email,
                PasswordHash = _passwordHasher.HashPassword(request.Password),
                Status = UserStatus.Active,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            
            await _userRepository.AddAsync(user);
            
            return user.Id;
        }
    }
}
