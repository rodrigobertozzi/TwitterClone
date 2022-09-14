using MediatR;
using Microsoft.AspNetCore.Mvc;

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

    }
}
