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

            var user = await _unitOfWork.Users.FirstAsync();
            if (user == null)
                throw new Exception();

            var followed = await _unitOfWork.Users.GetByUsernameAsync(request.Username);
            if (followed == null)
                throw new Exception();

            var removeFollow = await _unitOfWork.Follows.AnyAsync(request.Username);
            if (removeFollow == null)
                throw new Exception();
            else
                await _unitOfWork.Follows.Remove(removeFollow);

            await _unitOfWork.CompleteAsync();

            await _unitOfWork.CommitAsync();

            return "Você deixou de seguir essa pessoa";
        }
    }
}
