using IoTUserService.Domain.Entities;
using IoTUserService.Domain.Repositories;
using IoTUserService.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTUserService.Infrastructure.Repositories
{
    public class PermissionRepository : RepositoryBase<Permission>, IPermissionRepository
    {
        public PermissionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Permission>> GetPermissionsByRoleIdAsync(Guid roleId)
        { 
            return await _context.Permissions.Where(u => u.RoleId == roleId && !u.IsDeleted).ToListAsync();
        }
    } 
}
