using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Application.ViewModels;
using Twitter.Domain.Entities;
using Twitter.Domain.Models;

namespace Twitter.Application.Follows.Queries.GetUserFollows
{
    public class GetUserFollowsQuery : IRequest<PaginationResult<FollowViewModel>>
    {
        public GetUserFollowsQuery(string username)
        {
            Username = username;
        }

        public string Username { get; set; }
        public int Page { get; set; } = 1;
    }
}
