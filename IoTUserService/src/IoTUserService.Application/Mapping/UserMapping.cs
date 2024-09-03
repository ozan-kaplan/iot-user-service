using AutoMapper;
using IoTUserService.Application.Models;
using IoTUserService.Domain.Entities;

namespace IoTUserService.Application.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<User, UserDto>();
        }
    }
}
