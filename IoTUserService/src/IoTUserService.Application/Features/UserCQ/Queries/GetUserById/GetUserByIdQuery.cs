using IoTUserService.Application.Models;
using MediatR;

namespace IoTUserService.Application.Features.UserCQ.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
