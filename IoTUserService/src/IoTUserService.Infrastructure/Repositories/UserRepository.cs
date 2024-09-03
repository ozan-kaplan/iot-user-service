using IoTUserService.Application.Models;
using IoTUserService.Domain.Entities;
using IoTUserService.Domain.Repositories;
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
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {  
        public UserRepository(ApplicationDbContext context): base(context)  { }
         

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && !u.IsDeleted);
        }
    }
}
