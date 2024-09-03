using IoTUserService.Application.Models;
using MediatR;

namespace IoTUserService.Application.Features.RoleCQ.Queries.GetPagedRoles
{
    public class GetPagedRolesQuery : IRequest<PagedResultModel<RoleDto>>
    {
        public PagedQueryModel QueryModel { get; set; }
        public GetPagedRolesQuery(PagedQueryModel queryModel)
        {
            QueryModel = queryModel;
        }
    }
}
