using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Domain.Entities;

namespace Twitter.Application.Tweets.Commands.CreateTweet
{
    public class CreateTweetCommand : IRequest<int>
    {
        public CreateTweetCommand(string content)
        {
            Content = content;
        }

        public string Content { get; set; } = string.Empty;
    }
}
