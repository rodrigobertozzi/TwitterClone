using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Domain.Entities;
using Twitter.Domain.Services;
using Twitter.Infrastructure.Persistance;

namespace Twitter.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IAuthService _authService;
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _authService = authService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = new User(request.FullName, request.Name, request.Email, request.Username, passwordHash, request.BirthDate, request.Location, request.Bio);

            await _unitOfWork.BeginTransactionAsync();
            
            await _unitOfWork.Users.AddAsync(user);

            await _unitOfWork.CompleteAsync();

            await _unitOfWork.CommitAsync();

            return user.Id;
        }
    }
}
