using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Application.Follows.Commands.UnfollowUser
{
    public class UnfollowUserCommand : IRequest<string>
    {
        public int FollowerId { get; set; }
        public int FollowedId { get; set; }
    }
}
