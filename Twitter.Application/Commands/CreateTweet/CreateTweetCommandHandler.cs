﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Entities;
using Twitter.Core.Repositories;
using Twitter.Infrastructure.Persistance;

namespace Twitter.Application.Commands.CreateTweet
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
            var tweet = new Tweet(request.Content, request.IdTweet, request.IdUser);

            await _unitOfWork.BeginTransactionAsync();

            await _unitOfWork.Tweets.AddAsync(tweet);

            await _unitOfWork.CompleteAsync();

            await _unitOfWork.CommitAsync();

            return tweet.Id;
        }
    }
}
