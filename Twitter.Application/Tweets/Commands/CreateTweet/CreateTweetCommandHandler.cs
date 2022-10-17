using MediatR;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Domain.Entities;
using Twitter.Domain.Events;
using Twitter.Domain.Repositories;
using Twitter.Infrastructure.Persistance;

namespace Twitter.Application.Tweets.Commands.CreateTweet
{
    public class CreateTweetCommandHandler : IRequestHandler<CreateTweetCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateTweetCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateTweetCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            var user = await _unitOfWork.Users.FirstAsync();
            if (user == null)
                throw new Exception("Usuario não encontrado.");

            var tweet = new Tweet(request.Content);

            tweet.DomainEvents.Add(new TweetCreatedEvent(tweet));

            await _unitOfWork.Tweets.AddAsync(tweet);

            await _unitOfWork.CompleteAsync();

            await _unitOfWork.CommitAsync();

            return tweet.Id;
        }
    }
}
