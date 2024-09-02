using IoTUserService.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTUserService.Application.Features.Queries.GetPagedUsers
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
