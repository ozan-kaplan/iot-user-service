using IoTUserService.Application.Models;
using IoTUserService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTUserService.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id);
        Task<User?> GetByEmailAsync(string email);
        Task<PagedResultModel<User>> GetPagedAsync(int pageNumber, int pageSize, SortModel? sort, Dictionary<string, string>? filters);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
    }
}
