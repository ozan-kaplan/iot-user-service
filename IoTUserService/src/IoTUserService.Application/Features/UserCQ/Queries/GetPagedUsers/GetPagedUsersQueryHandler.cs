using AutoMapper;
using IoTUserService.Application.Models;
using IoTUserService.Domain.Repositories;
using MediatR;

namespace IoTUserService.Application.Features.UserCQ.Queries.GetPagedUsers
{
    public class GetPagedUsersQueryHandler : IRequestHandler<GetPagedUsersQuery, PagedResultModel<UserDto>>
    {

        private readonly List<string> _validColumns = new List<string> { "Email" };

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public GetPagedUsersQueryHandler(IUnitOfWork  unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedResultModel<UserDto>> Handle(GetPagedUsersQuery request, CancellationToken cancellationToken)
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

            var users = await _unitOfWork.Users.GetPagedAsync(request.QueryModel.PageNumber, request.QueryModel.PageSize, request.QueryModel.SortBy, request.QueryModel.SortAsc, request.QueryModel.Filters);
            var totalCount = await _unitOfWork.Users.Count(request.QueryModel.Filters);


            return new PagedResultModel<UserDto>(_mapper.Map<IEnumerable<UserDto>>(users), totalCount);

             
        }
    }
}
