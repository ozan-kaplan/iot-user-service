using IoTUserService.Domain.Entities;

namespace IoTUserService.Domain.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}
