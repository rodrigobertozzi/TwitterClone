using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.DTOs;

namespace Twitter.Application.Queries.GetAllFollowers
{
    public class GetAllFollowersQuery : IRequest<List<FollowerDTO>>
    {
        public string Username { get; set; }

        public GetAllFollowersQuery(string username)
        {
            Username = username;
        }
    }
}
