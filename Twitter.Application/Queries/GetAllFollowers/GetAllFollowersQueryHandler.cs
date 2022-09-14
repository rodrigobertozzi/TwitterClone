using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.DTOs;

namespace Twitter.Application.Queries.GetAllFollowers
{
    public class GetAllFollowersQueryHandler : IRequestHandler<GetAllFollowersQuery, List<FollowerDTO>>
    {
        public Task<List<FollowerDTO>> Handle(GetAllFollowersQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
