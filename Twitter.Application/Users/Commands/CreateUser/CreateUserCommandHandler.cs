using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Domain.Entities;
using Twitter.Infrastructure.Persistance;

namespace Twitter.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            var user = new User(
                request.FullName,
                request.Name,
                request.Email,
                request.Username,
                request.Password,
                request.BirthDate,
                request.Location,
                request.Bio);

            await _unitOfWork.Users.AddAsync(user);

            await _unitOfWork.CompleteAsync();

            await _unitOfWork.CommitAsync();

            return user.Id;
        }
    }
}
