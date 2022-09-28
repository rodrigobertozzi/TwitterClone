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
        public GetAllTweetsQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
        public string Query { get; set; } = String.Empty;
        public int Page { get; set; } = 1;
    }
}
