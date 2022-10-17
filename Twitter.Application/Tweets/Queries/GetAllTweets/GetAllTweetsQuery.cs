using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Application.ViewModels;
using Twitter.Domain.Models;

namespace Twitter.Application.Tweets.Queries.GetAllTweets
{
    public class GetAllTweetsQuery : IRequest<PaginationResult<TweetViewModel>>
    {
        public GetAllTweetsQuery(string username)
        {
            Username = username;
        }

        public string Username { get; private set; }
        public int Page { get; set; } = 1;
    }
}
