using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Application.Commands.DeleteTweet
{
    public class DeleteTweetCommandHandler : IRequestHandler<DeleteTweetCommand, Unit>
    {
        public Task<Unit> Handle(DeleteTweetCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
