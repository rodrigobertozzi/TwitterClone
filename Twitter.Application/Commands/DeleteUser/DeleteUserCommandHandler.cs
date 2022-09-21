﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Repositories;
using Twitter.Infrastructure.Persistance;

namespace Twitter.Application.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserCommandHandler(IUnitOfWork unitOfWork, ITweetRepository tweetRepository)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(request.Id);

            await _unitOfWork.BeginTransactionAsync();

            await _unitOfWork.Users.DeleteAsync(user);

            await _unitOfWork.CompleteAsync();

            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
