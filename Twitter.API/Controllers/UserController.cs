using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Twitter.Application.Users.Commands.CreateUser;
using Twitter.Application.Users.Commands.DeleteUser;
using Twitter.Application.Users.Commands.LoginUser;
using Twitter.Application.Users.Commands.UpdateUser;
using Twitter.Application.Users.Queries.GetUser;

namespace Twitter.API.Controllers
{
    [Route("api/users")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var query = new GetUserQuery(id);
            var user = _mediator.Send(query);
            return Ok(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Put([FromBody] LoginUserCommand command)
        {
            var loginUserViewModel = await _mediator.Send(command);

            if (loginUserViewModel == null)
                return BadRequest();

            return Ok(loginUserViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateUserCommand command)
        {
            await _mediator.Send(command);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteUserCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
