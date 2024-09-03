using AutoMapper;
using IoTUserService.Application.Models;
using IoTUserService.Domain.Repositories;
using MediatR;

namespace IoTUserService.Application.Features.UserCQ.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(request.Id);
            if (user == null)
                throw new Exception("User not found");

            return _mapper.Map<UserDto>(user);
        }
    }
}
