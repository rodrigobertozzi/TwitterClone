using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Application.Tweets.Commands.DeleteTweet
{
    public class DeleteTweetCommand : IRequest<Unit>
    {
        public DeleteTweetCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
