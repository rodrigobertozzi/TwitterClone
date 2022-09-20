using MediatR;
using Microsoft.AspNetCore.Mvc;
using Twitter.Application.Commands.CreateTweet;
using Twitter.Application.Commands.DeleteTweet;
using Twitter.Application.Queries.GetAllTweets;

namespace Twitter.API.Controllers
{
    [Route("api/tweets")]
    public class TweetController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TweetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string username)
        {
            var query = new GetAllTweetsQuery(username);
            var allTweetsByUser = await _mediator.Send(query);
            return Ok(allTweetsByUser);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTweetCommand command)
        {
            var tweet = await _mediator.Send(command);
            return Ok(tweet);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteTweetCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
