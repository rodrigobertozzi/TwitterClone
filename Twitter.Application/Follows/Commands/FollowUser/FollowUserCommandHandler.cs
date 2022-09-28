using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Domain.Entities;
using Twitter.Domain.DomainEvents;
using Twitter.Domain.Repositories;
using Twitter.Infrastructure.Persistance;
using static Twitter.Domain.DomainEvents.FollowedCreatedEvent;

namespace Twitter.Application.Follows.Commands.FollowUser
{
    public class FollowUserCommandHandler : IRequestHandler<FollowUserCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;

        public FollowUserCommandHandler(IUnitOfWork unitOfWork, ITweetRepository tweetRepository)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<string> Handle(FollowUserCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            var follow = await _unitOfWork.Follows.GetByIdAsync(request.FollowedId, request.FollowerId);
            if (follow != null)
                throw new Exception("Você já segue essa pessoa.");

            // implementar o alreadyFollowed

            var userFollow = new Follow { FollowedId = request.FollowedId, FollowerId = request.FollowerId };

            userFollow.DomainEvents.Add(new FollowedCreatedEvent(userFollow));

            await _unitOfWork.Follows.Add(userFollow);

            await _unitOfWork.CompleteAsync();

            await _unitOfWork.CommitAsync();

            return "Seguindo.";
        }
    }
}
