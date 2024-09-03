using IoTUserService.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTUserService.Application.Models
{
    public class PermissionDto
    {
        public PermissionResource Resource { get; set; }
        public PermissionOperation Operation { get; set; }
    }
}
