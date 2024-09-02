using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTUserService.Application.Models
{
    public class AuthenticateResponseDto
    {
        public AuthenticateResponseDto(string token)
        {
            Token = token;
        }
        public string Token { get; set; }
    }
}
