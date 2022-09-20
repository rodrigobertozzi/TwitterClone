using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.DTOs;

namespace Twitter.Application.Queries.GetAllFollowing
{
    public class GetAllFollowingQuery : IRequest<List<FollowingDTO>>
    {
        public string Username { get; set; }

        public GetAllFollowingQuery(string username)
        {
            Username = username;
        }
    }
}
