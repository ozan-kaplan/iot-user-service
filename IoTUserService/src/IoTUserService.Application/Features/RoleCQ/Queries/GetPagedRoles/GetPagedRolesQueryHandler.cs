using AutoMapper;
using IoTUserService.Application.Models;
using IoTUserService.Domain.Repositories;
using MediatR;

namespace IoTUserService.Application.Features.RoleCQ.Queries.GetPagedRoles
{
    public class GetPagedRolesQueryHandler : IRequestHandler<GetPagedRolesQuery, PagedResultModel<RoleDto>>
    {
        private readonly List<string> _validColumns = new List<string> { "Name" };

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPagedRolesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
         

        public async Task<PagedResultModel<RoleDto>> Handle(GetPagedRolesQuery request, CancellationToken cancellationToken)
        {
            if (request.QueryModel.Filters != null)
            {
                foreach (var filter in request.QueryModel.Filters.Keys)
                {
                    if (!_validColumns.Contains(filter))
                    {
                        throw new ArgumentException($"Invalid filter column: {filter}");
                    }
                }
            }

            var roles = await _unitOfWork.Roles.GetPagedAsync(request.QueryModel.PageNumber, request.QueryModel.PageSize, request.QueryModel.SortBy, request.QueryModel.SortAsc, request.QueryModel.Filters);
            var totalCount = await _unitOfWork.Roles.Count(request.QueryModel.Filters);


            return new PagedResultModel<RoleDto>(_mapper.Map<IEnumerable<RoleDto>>(roles), totalCount);
        }
    }
}
