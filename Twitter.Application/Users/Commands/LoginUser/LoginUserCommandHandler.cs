using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Application.ViewModels;
using Twitter.Domain.Services;
using Twitter.Infrastructure.Persistance;

namespace Twitter.Application.Users.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUnitOfWork _unitOfWork;
        public LoginUserCommandHandler(IUnitOfWork unitOfWork, IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _authService = authService;
        }
        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = await _unitOfWork.Users.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

            if (user == null)
                throw new Exception("Usuário não encontrado.");

            var token = _authService.GenerateJwtToken(user.Email);

            await _unitOfWork.CompleteAsync();

            await _unitOfWork.CommitAsync();

            return new LoginUserViewModel(user.Email, token);
        }
    }
}
