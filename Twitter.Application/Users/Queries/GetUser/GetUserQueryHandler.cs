using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Application.ViewModels;
using Twitter.Infrastructure.Persistance;

namespace Twitter.Application.Users.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetUserQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            var user = await _unitOfWork.Users.GetByIdAsync(request.Username);

            if (user == null)
                throw new ArgumentException("Não existe um usuário com esse username");

            var userViewModel = new UserViewModel(user.Name, user.Username, user.Bio, user.Location);

            await _unitOfWork.CompleteAsync();

            await _unitOfWork.CommitAsync();

            return userViewModel;
            
        }
    }
}
