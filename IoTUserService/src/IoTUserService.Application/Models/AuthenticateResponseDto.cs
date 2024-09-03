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
