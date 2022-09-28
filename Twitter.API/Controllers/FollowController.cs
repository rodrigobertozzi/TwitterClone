using MediatR;
using Microsoft.AspNetCore.Mvc;
using Twitter.Application.Follows.Commands.FollowUser;
using Twitter.Application.Follows.Commands.UnfollowUser;
using Twitter.Application.Follows.Queries.GetUserFollows;

namespace Twitter.API.Controllers
{
    [Route("api/users/{id}/")]
    public class FollowController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FollowController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserFollows(int id)
        {
            var query = new GetUserFollowsQuery(id);
            var followings = await _mediator.Send(query);
            return Ok(followings);
        }

        [HttpPost("follow")]
        public async Task<IActionResult> FollowUser(int followedId, int followerId)
        {
            var command = new FollowUserCommand { FollowedId = followedId, FollowerId = followerId };
            await _mediator.Send(command);
            return Ok(command);
        }

        [HttpPost("unfollow")]
        public async Task<IActionResult> UnfollowUser(int followedId, int followerId)
        {
            var command = new UnfollowUserCommand { FollowedId = followedId, FollowerId = followerId };
            await _mediator.Send(command);
            return Ok(command);
        }
    }
}
