using AutoMapper;
using IoTUserService.Application.Interfaces.Repositories;
using IoTUserService.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTUserService.Application.Features.Queries.GetUserById
{ 
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto?>
    {
        private readonly IUserRepository _deviceRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserRepository deviceRepository, IMapper mapper)
        {
            _deviceRepository = deviceRepository;
            _mapper = mapper;
        }

        public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<UserDto>(await _deviceRepository.GetByIdAsync(request.Id));
        }
    }
}
