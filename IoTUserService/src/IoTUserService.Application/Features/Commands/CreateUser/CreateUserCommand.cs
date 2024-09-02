using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTUserService.Application.Features.Commands.CreateUser
{
      
    public class CreateUserCommand : IRequest<Guid>
    {
        
        public required string Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? GSMNumber { get; set; }
        public required string Password { get; set; }
    }
}
