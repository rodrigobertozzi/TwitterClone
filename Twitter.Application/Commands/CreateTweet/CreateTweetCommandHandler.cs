using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Application.Commands.CreateTweet
{
    public class CreateTweetCommandHandler : IRequestHandler<CreateTweetCommand, int>
    {
        public Task<int> Handle(CreateTweetCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
