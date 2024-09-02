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
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<User, UserDto>();
            CreateMap<PagedResultModel<User>, PagedResultModel<UserDto>>();

        }
    }
}
