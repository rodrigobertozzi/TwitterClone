using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Domain.Repositories;
using Twitter.Infrastructure.Persistance;

namespace Twitter.Application.Tweets.Commands.DeleteTweet
{
    public class DeleteTweetCommandHandler : IRequestHandler<DeleteTweetCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public DeleteTweetCommandHandler(IUnitOfWork unitOfWork, ITweetRepository tweetRepository)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteTweetCommand request, CancellationToken cancellationToken)
        {
            var tweet = await _unitOfWork.Tweets.GetByIdAsync(request.Id);

            await _unitOfWork.BeginTransactionAsync();

            await _unitOfWork.Tweets.DeleteAsync(tweet);

            await _unitOfWork.CompleteAsync();

            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
