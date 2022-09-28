using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Application.ViewModels;
using Twitter.Domain.Entities;
using Twitter.Domain.Models;
using Twitter.Infrastructure.Persistance;

namespace Twitter.Application.Follows.Queries.GetUserFollows
{
    public class GetUserFollowsQueryHandler : IRequestHandler<GetUserFollowsQuery, PaginationResult<FollowViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetUserFollowsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PaginationResult<FollowViewModel>> Handle(GetUserFollowsQuery request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            var paginationFollows = await _unitOfWork.Follows.GetAllFollowsAsync(request.FollowerId, request.Page);

            var followsViewModel = paginationFollows
                .Data
                .Select(f => new FollowViewModel(f.Followed, f.FollowedId))
                .ToList();

            var paginationFollowsViewModel = new PaginationResult<FollowViewModel>(
                paginationFollows.Page,
                paginationFollows.TotalPages,
                paginationFollows.PageSize,
                paginationFollows.ItemsCount,
                followsViewModel
                );

            await _unitOfWork.CompleteAsync();

            await _unitOfWork.CommitAsync();

            return paginationFollowsViewModel;
        }
    }
}
