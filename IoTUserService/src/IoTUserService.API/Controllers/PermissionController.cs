using IoTUserService.Application.Features.PermissionCQ.Queries.GetPermissionsByUserId;
using IoTUserService.Application.Features.RoleCQ.Commands.AssignPermission;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IoTUserService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PermissionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userId}/permissions")]
        public async Task<IActionResult> GetPermissionsByUserId(Guid userId)
        { 
            return Ok(await _mediator.Send(new GetPermissionsByUserIdQuery(userId)));
        }
    }
}
