using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Application.Follows.Commands.UnfollowUser
{
    public class UnfollowUserCommand : IRequest
    {
        public string Username { get; set; }

        public UnfollowUserCommand(string username)
        {
            Username = username;
        }
    }
}
