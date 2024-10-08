﻿using IoTUserService.Application.Features.UserCQ.Commands.CreateUser;
using IoTUserService.Application.Features.UserCQ.Commands.DeleteUser;
using IoTUserService.Application.Features.UserCQ.Commands.UpdateUser;
using IoTUserService.Application.Features.UserCQ.Queries.GetPagedUsers;
using IoTUserService.Application.Features.UserCQ.Queries.GetUserById;
using IoTUserService.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IoTUserService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var device = await _mediator.Send(new GetUserByIdQuery(id));
            if (device == null)
            {
                return NotFound();
            }
            return Ok(device);
        }

        [HttpGet]
        public async Task<IActionResult> GetPagedUsers([FromQuery] PagedQueryModel queryModel)
        {
            var query = new GetPagedUsersQuery(queryModel);
            var devices = await _mediator.Send(query);
            return Ok(devices);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UpdateUserCommand command)
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
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _mediator.Send(new DeleteUserCommand(id));
            return NoContent();  
        }
    }
}
