using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.DTOs;

namespace Twitter.Application.Queries.GetAllFollowing
{
    public class GetAllFollowingQueryHandler : IRequestHandler<GetAllFollowingQuery, List<FollowingDTO>>
    {
        public Task<List<FollowingDTO>> Handle(GetAllFollowingQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
