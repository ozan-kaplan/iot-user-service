using IoTUserService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTUserService.Domain.Repositories
{
    public interface IPermissionRepository: IRepositoryBase<Permission>
    {
        Task<IEnumerable<Permission>> GetPermissionsByRoleIdAsync(Guid roleId);
    }
}
