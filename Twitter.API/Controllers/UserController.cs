using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Twitter.Application.Commands.CreateUser;
using Twitter.Application.Commands.DeleteUser;
using Twitter.Application.Commands.LoginUser;
using Twitter.Application.Queries.GetAllFollowers;
using Twitter.Application.Queries.GetAllFollowing;
using Twitter.Application.Queries.GetUser;

namespace Twitter.API.Controllers
{
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByUsername(int id)
        {
            var query = new GetUserQuery(id);
            var user = await _mediator.Send(query);
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFollowers(int id)
        {
            var query = new GetAllFollowersQuery(id);
            var followers = await _mediator.Send(query);
            return Ok(followers);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFollowings(int id)
        {
            var query = new GetAllFollowingQuery(id);
            var followings = await _mediator.Send(query);
            return Ok(followings);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetByUsername), new { id = 1 }, command);
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteUserCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
