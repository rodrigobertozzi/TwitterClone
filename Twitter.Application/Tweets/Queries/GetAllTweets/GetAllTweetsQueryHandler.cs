using MediatR;
using Twitter.Application.ViewModels;
using Twitter.Domain.Models;
using Twitter.Infrastructure.Persistance;

namespace Twitter.Application.Tweets.Queries.GetAllTweets
{
    public class GetAllTweetsQueryHandler : IRequestHandler<GetAllTweetsQuery, PaginationResult<TweetViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllTweetsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginationResult<TweetViewModel>> Handle(GetAllTweetsQuery request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            var paginationTweets = await _unitOfWork.Tweets.GetAllAsync(request.Username, request.Page);

            var tweetsViewModel = paginationTweets
                .Data
                .Select(t => new TweetViewModel(t.Content))
                .ToList();
            
            var paginationTweetsViewModel = new PaginationResult<TweetViewModel>(
                paginationTweets.Page,
                paginationTweets.TotalPages,
                paginationTweets.PageSize,
                paginationTweets.ItemsCount,
                tweetsViewModel
                );

            await _unitOfWork.CompleteAsync();

            await _unitOfWork.CommitAsync();

            return paginationTweetsViewModel;
        }
    }
}
