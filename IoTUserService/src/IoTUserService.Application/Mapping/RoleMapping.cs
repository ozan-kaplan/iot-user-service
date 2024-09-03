using AutoMapper;
using IoTUserService.Application.Models;
using IoTUserService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTUserService.Application.Mapping
{
    public class RoleMapping: Profile
    {
        public RoleMapping()
        {
            CreateMap<Role,RoleDto>();
        }
    }
}
