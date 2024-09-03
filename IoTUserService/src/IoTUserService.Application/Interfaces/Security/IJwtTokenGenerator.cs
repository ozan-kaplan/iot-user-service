using IoTUserService.Domain.Entities;

namespace IoTUserService.Application.Interfaces.Security
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
