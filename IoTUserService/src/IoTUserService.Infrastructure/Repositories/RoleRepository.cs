using IoTUserService.Domain.Entities;
using IoTUserService.Domain.Repositories;
using IoTUserService.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTUserService.Infrastructure.Repositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository 
    {
        public RoleRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
