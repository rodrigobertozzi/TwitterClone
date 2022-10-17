using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Domain.Entities;
using Twitter.Domain.Events;
using Twitter.Domain.Repositories;
using Twitter.Infrastructure.Persistance;
using static Twitter.Domain.Events.FollowedCreatedEvent;

namespace Twitter.Application.Follows.Commands.FollowUser
{
    public class FollowUserCommandHandler : IRequestHandler<FollowUserCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;

        public FollowUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<string> Handle(FollowUserCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            var user = await _unitOfWork.Users.FirstAsync();
            if (user == null)
                throw new Exception();

            var followed = await _unitOfWork.Users.GetByUsernameAsync(request.Username);
            if (user == null)
                throw new Exception();

            var alreadyFollowed = await _unitOfWork.Follows.AnyAsync(request.Username);
            if (alreadyFollowed != null)
                throw new Exception("você já segue essa pessoa");

            var userFollow = new Follow { FollowedId = followed.Id, FollowerId = user.Id };

            userFollow.DomainEvents.Add(new FollowedCreatedEvent(userFollow));

            await _unitOfWork.Follows.Add(userFollow);

            await _unitOfWork.CompleteAsync();

            await _unitOfWork.CommitAsync();

            return "Seguindo.";
        }
    }
}
