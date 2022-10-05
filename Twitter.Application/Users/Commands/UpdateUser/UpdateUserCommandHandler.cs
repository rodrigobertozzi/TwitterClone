using MediatR;
using Twitter.Domain.Entities;
using Twitter.Infrastructure.Persistance;

namespace Twitter.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public UpdateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            var user = await _unitOfWork.Users.FirstAsync();

            user.UpdateUser(request.Name, request.Email, request.Username, request.Password, request.BirthDate, request.Bio, request.Location);

            await _unitOfWork.Users.UpdateUserAsync(user);

            await _unitOfWork.CompleteAsync();

            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }    
    }
}
