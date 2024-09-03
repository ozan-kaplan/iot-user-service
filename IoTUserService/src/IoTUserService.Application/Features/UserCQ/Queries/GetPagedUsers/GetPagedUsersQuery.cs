using IoTUserService.Application.Models;
using MediatR;

namespace IoTUserService.Application.Features.UserCQ.Queries.GetPagedUsers
{
    public class GetPagedUsersQuery : IRequest<PagedResultModel<UserDto>>
    {
        public PagedQueryModel QueryModel { get; set; }

        public GetPagedUsersQuery(PagedQueryModel queryModel)
        {
            QueryModel = queryModel;
        }
    }
}
