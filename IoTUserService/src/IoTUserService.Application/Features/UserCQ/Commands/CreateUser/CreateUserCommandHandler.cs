using IoTUserService.Application.Interfaces.Security;
using IoTUserService.Domain.Entities;
using IoTUserService.Domain.Repositories;
using MediatR;

namespace IoTUserService.Application.Features.UserCQ.Commands.CreateUser
{

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            var existingUser = await _unitOfWork.Users.GetByEmailAsync(request.Email);
            if (existingUser != null)
                throw new Exception("User with this email already exists.");

            if (request.Authority == UserAuthority.SystemAdmin)
                throw new Exception("System Admin cannot be created by this method.");

            var hashedPassword = _passwordHasher.HashPassword(request.Password);

            var user = new User
            {
                Id = Guid.NewGuid(),
                Status = UserStatus.Active,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Authority = request.Authority,
                CustomerId = request.CustomerId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                GSMNumber = request.GSMNumber,
                Email = request.Email,
                PasswordHash = hashedPassword,

            };

            await _unitOfWork.Users.AddAsync(user);

            await _unitOfWork.SaveChangesAsync();

            return user.Id;
        }
    }
}
