using AutoMapper;
using IoTUserService.Application.Interfaces.Repositories;
using IoTUserService.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTUserService.Application.Features.Queries.GetPagedUsers
{
    public class GetPagedUsersQueryHandler : IRequestHandler<GetPagedUsersQuery, PagedResultModel<UserDto>>
    {

        private readonly List<string> _validColumns = new List<string> { "Email" };

        private readonly IUserRepository _deviceRepository;
        private readonly IMapper _mapper;

        public GetPagedUsersQueryHandler(IUserRepository deviceRepository, IMapper mapper)
        {
            _deviceRepository = deviceRepository;
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

            return _mapper.Map<PagedResultModel<UserDto>>(await _deviceRepository.GetPagedAsync(
                   request.QueryModel.PageNumber,
                   request.QueryModel.PageSize,
                   request.QueryModel.Sort,
                   request.QueryModel.Filters));
        }
    }
}
