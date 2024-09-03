using IoTUserService.Application.Features.RoleCQ.Commands.AssignPermission;
using IoTUserService.Application.Features.RoleCQ.Commands.CreateRole;
using IoTUserService.Application.Features.RoleCQ.Commands.DeleteRole;
using IoTUserService.Application.Features.RoleCQ.Commands.UpdateRole;
using IoTUserService.Application.Features.RoleCQ.Queries.GetPagedRoles;
using IoTUserService.Application.Features.RoleCQ.Queries.GetRoleById;
using IoTUserService.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IoTUserService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(Guid id)
        {
            var device = await _mediator.Send(new GetRoleByIdQuery(id));
            if (device == null)
            {
                return NotFound();
            }
            return Ok(device);
        }

        [HttpGet]
        public async Task<IActionResult> GetPagedRoles([FromQuery] PagedQueryModel queryModel)
        {
            var query = new GetPagedRolesQuery(queryModel);
            var devices = await _mediator.Send(query);
            return Ok(devices);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(Guid id, [FromBody] UpdateRoleCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _mediator.Send(new DeleteRoleCommand(id));
            return NoContent();
        }

        [HttpPost("{roleId}/assign-permissions")]
        public async Task<IActionResult> AssignPermissionsToRole(Guid roleId, [FromBody] AssignPermissionsToRoleCommand command)
        {  
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
