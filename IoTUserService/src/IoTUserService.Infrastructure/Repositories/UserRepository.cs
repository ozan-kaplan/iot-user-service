using IoTUserService.Application.Interfaces.Repositories;
using IoTUserService.Application.Models;
using IoTUserService.Domain.Entities;
using IoTUserService.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace IoTUserService.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }
        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id && !u.IsDeleted);

        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<PagedResultModel<User>> GetPagedAsync(int pageNumber, int pageSize, SortModel? sort, Dictionary<string, string>? filters)
        {
            var query = _context.Users.Where(d => !d.IsDeleted);

            if (filters != null)
                foreach (var filter in filters)
                    query = query.Where($"{filter.Key}.Contains(@0)", filter.Value);

            var totalRecords = await query.CountAsync();

            if (sort != null && !string.IsNullOrEmpty(sort.SortBy))
                query = sort.SortDirection == SortDirection.Descending ? query.OrderBy($"{sort.SortBy} descending") : query.OrderBy(sort.SortBy);

            var items = await query.Skip((pageNumber - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToListAsync();

            return new PagedResultModel<User>(items, totalRecords);
        }

   
    }
}
