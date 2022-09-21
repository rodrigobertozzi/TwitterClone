using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Entities;

namespace Twitter.Application.Commands.CreateTweet
{
    public class CreateTweetCommand : IRequest<int>
    {
        public CreateTweetCommand()
        {

        }

        public int IdTweet { get; set; }
        public int IdUser { get; set; }
        public string Content { get; set; } = string.Empty;
        public User Username { get; set; } = new User();
    }
}
