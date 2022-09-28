using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Infrastructure.Persistance;

namespace Twitter.Application.Follows.Commands.UnfollowUser
{
    public class UnfollowUserCommandHandler : IRequestHandler<UnfollowUserCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UnfollowUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<string> Handle(UnfollowUserCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            var follow = await _unitOfWork.Follows.GetByIdAsync(request.FollowerId, request.FollowerId);
            if (follow == null)
                throw new Exception("Você não segue essa pessoa");
            else
                await _unitOfWork.Follows.Remove(follow);
            
            await _unitOfWork.CompleteAsync();

            await _unitOfWork.CommitAsync();

            return "Você deixou de seguir essa pessoa";
        }
    }
}
