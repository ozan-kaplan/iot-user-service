using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTUserService.Application.Models
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? GSMNumber { get; set; }
        public required string Email { get; set; }
    }
}
