using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Application.Commands.CreateTweet
{
    public class CreateTweetCommand : IRequest<int>
    {
        public CreateTweetCommand(string content)
        {
            Content = content;
        }

        public int IdTweet { get; private set; }
        public string Content { get; private set; }
    }
}
