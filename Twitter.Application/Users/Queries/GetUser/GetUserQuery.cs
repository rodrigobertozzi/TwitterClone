using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Application.ViewModels;

namespace Twitter.Application.Users.Queries.GetUser
{
    public class GetUserQuery : IRequest<UserViewModel>
    {
        public GetUserQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Username { get; private set; } = string.Empty;
        public string Bio { get; private set; } = string.Empty;
        public string Location { get; private set; } = string.Empty;
    }
}
