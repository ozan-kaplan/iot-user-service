using IoTUserService.Domain.Entities;
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

        public UserAuthority Authority { get; set; }

        public CreateUserCommand(Guid customerId, string email, string password, UserAuthority authority)
        {
            CustomerId = customerId;
            Email = email;
            Password = password;
            Authority = authority;
        }

        public CreateUserCommand(Guid customerId, string email, string password, UserAuthority authority, string firstName, string lastName, string gsmNumber)
        {
            CustomerId = customerId;
            Email = email;
            Password = password;
            Authority = authority;
            FirstName = firstName;
            LastName = lastName;
            GSMNumber = gsmNumber;
        }
    }
}
